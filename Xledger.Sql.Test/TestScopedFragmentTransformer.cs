using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Xledger.Sql.Test {
    public class TestScopedFragmentTransformer {
        static TSqlFragment Parse(string sql) {
            var parser = new TSql150Parser(false);
            using (var txt = new StringReader(sql)) {
                var frag = parser.Parse(txt, out var errors);
                if (errors?.Count > 0) {
                    throw new Exception($"{errors[0].Number} ({errors[0].Line}, {errors[0].Column}): {errors[0].Message}");
                }
                return frag;
            }
        }

        const string SQL = @"
SELECT a.foo, a.bar, a.baz, b.cow, b.bull, chicken, barn, (SELECT TOP 1 dog FROM pound) AS fluffyPuppy
  FROM table0 a, farmhouse b
 WHERE b.barn IN (SELECT location FROM farms d
                  UNION
                  SELECT e.address FROM rentals e)";

        [Fact]
        public void TestCollectColRefs() {
            var frag = Parse(SQL);

            var colRefs = new List<ColumnReferenceExpression>();
            var columnNames = new HashSet<string>();
            frag.Accept(new ScopedFragmentTransformer {
                VisForColumnReferenceExpression = (vis, colRef) => {
                    colRefs.Add(colRef);
                    columnNames.Add(colRef.MultiPartIdentifier.Identifiers.Last().Value);
                },
            });

            Assert.Equal(11, colRefs.Count);
            Assert.Equal(10, columnNames.Count);

            Assert.Contains("foo", columnNames);
            Assert.Contains("bar", columnNames);
            Assert.Contains("baz", columnNames);
            Assert.Contains("cow", columnNames);
            Assert.Contains("bull", columnNames);
            Assert.Contains("chicken", columnNames);
            Assert.Contains("barn", columnNames);
            Assert.Contains("dog", columnNames);
            Assert.Contains("location", columnNames);
            Assert.Contains("address", columnNames);
            Assert.Contains("foo", columnNames);

            Assert.True(columnNames.Remove("foo"));
            Assert.True(columnNames.Remove("bar"));
            Assert.True(columnNames.Remove("baz"));
            Assert.True(columnNames.Remove("cow"));
            Assert.True(columnNames.Remove("bull"));
            Assert.True(columnNames.Remove("chicken"));
            Assert.True(columnNames.Remove("barn"));
            Assert.True(columnNames.Remove("dog"));
            Assert.True(columnNames.Remove("location"));
            Assert.True(columnNames.Remove("address"));

            Assert.Empty(columnNames);
        }

        [Fact]
        public void TestScoping() {
            var frag = Parse(SQL);
            var columnNames = new HashSet<string>();
            frag.Accept(new ScopedFragmentTransformer {
                VisForColumnReferenceExpression = (vis, colRef) => {
                    // Only visit column references at the top-level.
                    var qspec = vis.Parents.OfType<QuerySpecification>().ToList();
                    if (qspec.Count != 1) {
                        return;
                    }

                    columnNames.Add(colRef.MultiPartIdentifier.Identifiers.Last().Value);
                },
            });

            Assert.Equal(7, columnNames.Count);

            Assert.Contains("foo", columnNames);
            Assert.Contains("bar", columnNames);
            Assert.Contains("baz", columnNames);
            Assert.Contains("cow", columnNames);
            Assert.Contains("bull", columnNames);
            Assert.Contains("chicken", columnNames);
            Assert.Contains("barn", columnNames);

            Assert.True(columnNames.Remove("foo"));
            Assert.True(columnNames.Remove("bar"));
            Assert.True(columnNames.Remove("baz"));
            Assert.True(columnNames.Remove("cow"));
            Assert.True(columnNames.Remove("bull"));
            Assert.True(columnNames.Remove("chicken"));
            Assert.True(columnNames.Remove("barn"));

            Assert.Empty(columnNames);
        }
    }
}
