using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xledger.Sql.ImmutableDom;
using Xunit;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Xledger.Sql.Test {
    public class TestImmutableDom {
        [Fact]
        public void TestCompareTo() {
            var a = new ColumnReferenceExpression(
                multiPartIdentifier: new MultiPartIdentifier(
                    identifiers: new[] {
                        new Identifier("a"),
                        new Identifier("column"),
                    }));
            var b = new ColumnReferenceExpression(
                multiPartIdentifier: new MultiPartIdentifier(
                    identifiers: new[] {
                        new Identifier("a"),
                        new Identifier("column"),
                    }));
            var c = new ColumnReferenceExpression(
                multiPartIdentifier: new MultiPartIdentifier(
                    identifiers: new[] {
                        new Identifier("c"),
                        new Identifier("column"),
                    }));

            Assert.True(a.CompareTo(null) > 0);
            Assert.Equal(0, a.CompareTo(a));
            Assert.Equal(0, a.CompareTo(b));
            Assert.Equal(0, b.CompareTo(a));
            Assert.True(a.CompareTo(c) < 0);
            Assert.True(c.CompareTo(a) > 0);

            TSqlFragment aFrag = a;
            TSqlFragment bFrag = b;
            TSqlFragment cFrag = c;

            Assert.True(aFrag.CompareTo(null) > 0);
            Assert.Equal(0, aFrag.CompareTo(aFrag));
            Assert.Equal(0, aFrag.CompareTo(bFrag));
            Assert.Equal(0, b.CompareTo(aFrag));
            Assert.True(aFrag.CompareTo(cFrag) < 0);
            Assert.True(cFrag.CompareTo(aFrag) > 0);
        }

        [Fact]
        public void TestCompareToSubtypes() {
            var a = new ViewOption(Microsoft.SqlServer.TransactSql.ScriptDom.ViewOptionKind.Distribution);
            var b = new ViewForAppendOption(Microsoft.SqlServer.TransactSql.ScriptDom.ViewOptionKind.SchemaBinding);

            Assert.True(a.CompareTo(b) != 0);
            Assert.True(b.CompareTo(a) != 0);
            // The order between the base class and sub class must be preserved between the two comparisons.
            if (a.CompareTo(b) < 0) {
                Assert.True(b.CompareTo(a) > 0);
            } else {
                Assert.True(b.CompareTo(a) < 0);
            }
        }

        [Fact]
        public void TestCompareToCaseInsensitivity() {
            var a = new ColumnReferenceExpression(
                multiPartIdentifier: new MultiPartIdentifier(
                    identifiers: new[] {
                        new Identifier("a"),
                        new Identifier("column"),
                    }));
            var b = new ColumnReferenceExpression(
                multiPartIdentifier: new MultiPartIdentifier(
                    identifiers: new[] {
                        new Identifier("A"),
                        new Identifier("COLUMN"),
                    }));
            
            Assert.Equal(0, a.CompareTo(a));
            Assert.Equal(0, a.CompareTo(b));
            Assert.Equal(0, b.CompareTo(a));
        }

        [Fact]
        public void TestToMutable() {
            var immA = new VariableReference(name: "a");
            var a = immA.ToMutableConcrete();

            Assert.NotNull(a);
            Assert.Equal(immA.Name, a.Name);
            Assert.Null(a.Collation);
        }

        [Fact]
        public void TestFromMutable() {
            var dom = Parse(NESTED_SQL);
            var frag = TSqlFragment.FromMutable(dom);

            Assert.NotNull(frag);

            var sql = "SELECT 1 OPTION(USE HINT('DISABLE_TSQL_SCALAR_UDF_INLINING'))";
            dom = Parse(sql);
            var script = (ScriptDom.TSqlScript)dom;
            var stmt = script.Batches[0].Statements[0] as ScriptDom.SelectStatement;
            Assert.NotEmpty(stmt.OptimizerHints);
            ScriptDom.OptimizerHint hint = stmt.OptimizerHints.First();
            Assert.NotNull(hint);
            Assert.IsType<ScriptDom.UseHintList>(hint);
            var useHintList = hint as ScriptDom.UseHintList;
            Assert.Equal(ScriptDom.OptimizerHintKind.Unspecified, useHintList.HintKind);
            Assert.Single(useHintList.Hints);
            Assert.Equal("DISABLE_TSQL_SCALAR_UDF_INLINING", useHintList.Hints[0].Value);

            OptimizerHint immHint = OptimizerHint.FromMutable(hint);
            Assert.NotNull(immHint);
            Assert.IsType<UseHintList>(immHint);
            var immUseHintList = immHint as UseHintList;
            Assert.Equal(ScriptDom.OptimizerHintKind.Unspecified, immUseHintList.HintKind);
            Assert.Single(immUseHintList.Hints);
            Assert.Equal("DISABLE_TSQL_SCALAR_UDF_INLINING", immUseHintList.Hints[0].Value);
        }

        [Fact]
        public void TestDomEquality() {
            var sql = @"select 1 as foo, 'hah' as foo 
from bar a, baz f";
            var fragments = new HashSet<TSqlFragment> {
                TSqlFragment.FromMutable(Parse(sql))
            };

            Assert.False(fragments.Add(TSqlFragment.FromMutable(Parse(sql))), "Equal fragment added to set twice");
        }

        [Fact]
        public void TestDomHashCode() {
            var sql = @"select 1 as foo, 'hah' as foo 
from bar a, baz f";
            var first = TSqlFragment.FromMutable(Parse(sql));
            var second = TSqlFragment.FromMutable(Parse(sql));
            Assert.Equal(first.GetHashCode(), second.GetHashCode());

            var third = TSqlFragment.FromMutable(Parse("select 2 as foo from bar a, baz f"));
            Assert.NotEqual(first.GetHashCode(), third.GetHashCode());
        }

        [Fact]
        public void TestFromMutableStackUse() {
            //PadStack(4500, TestFromMutableActual);
            PadStack(1200, TestFromMutable);
            //PadStack(2500, TestFromMutableActual);
            //PadStack(3500, TestFromMutableActual);
            //PadStack(0, TestFromMutableActual);
        }

        const string NESTED_SQL = @"
SELECT JSON_QUERY((SELECT (SELECT   CONVERT (NVARCHAR (20), [a].[id]) AS 'cursor',
                                    [a].[id] AS 'node.id',
                                    NULLIF ([a].[str], '') AS 'node.str',
                                    JSON_QUERY((SELECT   [id] AS 'id',
                                                         NULLIF ([str], '') AS 'str',
                                                         JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT   JSON_QUERY((SELECT [z].[num] AS 'id'
                                                                                                                                                                                                                                             WHERE  [z].[num] <> 0
                                                                                                                                                                                                                                             FOR    JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'id'
                                                                                                                                                                                                                        FROM     table1 AS [z] WITH (NOLOCK)
                                                                                                                                                                                                                        WHERE    y.num = z.id
                                                                                                                                                                                                                                 AND [z].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                                                                                                                                        ORDER BY [z].[id] ASC
                                                                                                                                                                                                                        FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'z'
                                                                                                                                                                                                   FROM     table1 AS [y] WITH (NOLOCK)
                                                                                                                                                                                                   WHERE    x.num = y.id
                                                                                                                                                                                                            AND [y].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                                                                                                                   ORDER BY [y].[id] ASC
                                                                                                                                                                                                   FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'y'
                                                                                                                                                                              FROM     table1 AS [x] WITH (NOLOCK)
                                                                                                                                                                              WHERE    w.num = x.id
                                                                                                                                                                                       AND [x].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                                                                                              ORDER BY [x].[id] ASC
                                                                                                                                                                              FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'x'
                                                                                                                                                         FROM     table1 AS [w] WITH (NOLOCK)
                                                                                                                                                         WHERE    v.num = w.id
                                                                                                                                                                  AND [w].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                                                                         ORDER BY [w].[id] ASC
                                                                                                                                                         FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'w'
                                                                                                                                    FROM     table1 AS [v] WITH (NOLOCK)
                                                                                                                                    WHERE    u.num = v.id
                                                                                                                                             AND [v].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                                                    ORDER BY [v].[id] ASC
                                                                                                                                    FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'v'
                                                                                                               FROM     table1 AS [u] WITH (NOLOCK)
                                                                                                               WHERE    t.num = u.id
                                                                                                                        AND [u].[num] IN (SELECT [id] FROM @tableVar)
                                                                                                               ORDER BY [u].[id] ASC
                                                                                                               FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'u'
                                                                                          FROM     table1 AS [t] WITH (NOLOCK)
                                                                                          WHERE    s.num = t.id
                                                                                                   AND [t].[num] IN (SELECT [id] FROM @tableVar)
                                                                                          ORDER BY [t].[id] ASC
                                                                                          FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 't'
                                                                     FROM     table2 AS [s] WITH (NOLOCK)
                                                                     WHERE    r.num = s.id
                                                                              AND [s].[num] IN (SELECT [id] FROM @tableVar)
                                                                     ORDER BY [s].[id] ASC
                                                                     FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 's'
                                                FROM     table3 AS [r] WITH (NOLOCK)
                                                WHERE    r.id = (SELECT TOP 1 p1.rv_level_parent
                                                                      FROM   table2 AS p1 WITH (NOLOCK)
                                                                      WHERE  p1.id = a.id)
                                                         AND [r].[num] IN (SELECT [id] FROM @tableVar)
                                                ORDER BY [r].[id] ASC
                                                FOR      JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'node.r'
                           FROM     table3 AS [a] WITH (NOLOCK)
                                    INNER JOIN @tableVar AS [b] ON a.id = b.id
                           ORDER BY [b].[num] ASC
                           FOR      JSON PATH, INCLUDE_NULL_VALUES) AS 'edges'
                   FOR    JSON PATH, WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES)) AS 'projects'
FOR    JSON PATH, WITHOUT_ARRAY_WRAPPER;
";

        public static ScriptDom.TSqlFragment Parse(string sql) {
            var p = new ScriptDom.TSql150Parser(false);
            var frag = p.Parse(new StringReader(sql), out var errors);
            if (errors?.Count > 0) {
                throw new System.Exception(errors[0].Message);
            }
            return frag;
        }

        public static int PadStack(int j, Action a) {
            int i0 = j + 0;
            int i1 = j + 1;
            int i2 = j + 2;
            int i3 = j + 3;
            int i4 = j + 4;
            int i5 = j + 5;
            int i6 = j + 6;
            int i7 = j + 7;
            int i8 = j + 8;
            int i9 = j + 9;
            int i10 = j + 10;
            int i11 = j + 11;
            int i12 = j + 12;
            int i13 = j + 13;
            int i14 = j + 14;
            int i15 = j + 15;
            int i16 = j + 16;
            int i17 = j + 17;
            int i18 = j + 18;
            int i19 = j + 19;
            int i20 = j + 20;
            int i21 = j + 21;
            int i22 = j + 22;
            int i23 = j + 23;
            int i24 = j + 24;
            int i25 = j + 25;
            int i26 = j + 26;
            int i27 = j + 27;
            int i28 = j + 28;
            int i29 = j + 29;
            int i30 = j + 30;
            int i31 = j + 31;
            int i32 = j + 32;
            int i33 = j + 33;
            int i34 = j + 34;
            int i35 = j + 35;
            int i36 = j + 36;
            int i37 = j + 37;
            int i38 = j + 38;
            int i39 = j + 39;
            int i40 = j + 40;
            int i41 = j + 41;
            int i42 = j + 42;
            int i43 = j + 43;
            int i44 = j + 44;
            int i45 = j + 45;
            int i46 = j + 46;
            int i47 = j + 47;
            int i48 = j + 48;
            int i49 = j + 49;
            int i50 = j + 50;
            int i51 = j + 51;
            int i52 = j + 52;
            int i53 = j + 53;
            int i54 = j + 54;
            int i55 = j + 55;
            int i56 = j + 56;
            int i57 = j + 57;
            int i58 = j + 58;
            int i59 = j + 59;
            int i60 = j + 60;
            int i61 = j + 61;
            int i62 = j + 62;
            int i63 = j + 63;
            int i64 = j + 64;
            int i65 = j + 65;
            int i66 = j + 66;
            int i67 = j + 67;
            int i68 = j + 68;
            int i69 = j + 69;
            int i70 = j + 70;
            int i71 = j + 71;
            int i72 = j + 72;
            int i73 = j + 73;
            int i74 = j + 74;
            int i75 = j + 75;
            int i76 = j + 76;
            int i77 = j + 77;
            int i78 = j + 78;
            int i79 = j + 79;
            int i80 = j + 80;
            int i81 = j + 81;
            int i82 = j + 82;
            int i83 = j + 83;
            int i84 = j + 84;
            int i85 = j + 85;
            int i86 = j + 86;
            int i87 = j + 87;
            int i88 = j + 88;
            int i89 = j + 89;
            int i90 = j + 90;
            int i91 = j + 91;
            int i92 = j + 92;
            int i93 = j + 93;
            int i94 = j + 94;
            int i95 = j + 95;
            int i96 = j + 96;
            int i97 = j + 97;
            int i98 = j + 98;
            int i99 = j + 99;

            switch (j) {
                case 0: a(); return i0;
                case 1: return PadStack(j - 1, a) + i1;
                case 2: return PadStack(j - 1, a) + i2;
                case 3: return PadStack(j - 1, a) + i3;
                case 4: return PadStack(j - 1, a) + i4;
                case 5: return PadStack(j - 1, a) + i5;
                case 6: return PadStack(j - 1, a) + i6;
                case 7: return PadStack(j - 1, a) + i7;
                case 8: return PadStack(j - 1, a) + i8;
                case 9: return PadStack(j - 1, a) + i9;
                case 10: return PadStack(j - 1, a) + i10;
                case 11: return PadStack(j - 1, a) + i11;
                case 12: return PadStack(j - 1, a) + i12;
                case 13: return PadStack(j - 1, a) + i13;
                case 14: return PadStack(j - 1, a) + i14;
                case 15: return PadStack(j - 1, a) + i15;
                case 16: return PadStack(j - 1, a) + i16;
                case 17: return PadStack(j - 1, a) + i17;
                case 18: return PadStack(j - 1, a) + i18;
                case 19: return PadStack(j - 1, a) + i19;
                case 20: return PadStack(j - 1, a) + i20;
                case 21: return PadStack(j - 1, a) + i21;
                case 22: return PadStack(j - 1, a) + i22;
                case 23: return PadStack(j - 1, a) + i23;
                case 24: return PadStack(j - 1, a) + i24;
                case 25: return PadStack(j - 1, a) + i25;
                case 26: return PadStack(j - 1, a) + i26;
                case 27: return PadStack(j - 1, a) + i27;
                case 28: return PadStack(j - 1, a) + i28;
                case 29: return PadStack(j - 1, a) + i29;
                case 30: return PadStack(j - 1, a) + i30;
                case 31: return PadStack(j - 1, a) + i31;
                case 32: return PadStack(j - 1, a) + i32;
                case 33: return PadStack(j - 1, a) + i33;
                case 34: return PadStack(j - 1, a) + i34;
                case 35: return PadStack(j - 1, a) + i35;
                case 36: return PadStack(j - 1, a) + i36;
                case 37: return PadStack(j - 1, a) + i37;
                case 38: return PadStack(j - 1, a) + i38;
                case 39: return PadStack(j - 1, a) + i39;
                case 40: return PadStack(j - 1, a) + i40;
                case 41: return PadStack(j - 1, a) + i41;
                case 42: return PadStack(j - 1, a) + i42;
                case 43: return PadStack(j - 1, a) + i43;
                case 44: return PadStack(j - 1, a) + i44;
                case 45: return PadStack(j - 1, a) + i45;
                case 46: return PadStack(j - 1, a) + i46;
                case 47: return PadStack(j - 1, a) + i47;
                case 48: return PadStack(j - 1, a) + i48;
                case 49: return PadStack(j - 1, a) + i49;
                case 50: return PadStack(j - 1, a) + i50;
                case 51: return PadStack(j - 1, a) + i51;
                case 52: return PadStack(j - 1, a) + i52;
                case 53: return PadStack(j - 1, a) + i53;
                case 54: return PadStack(j - 1, a) + i54;
                case 55: return PadStack(j - 1, a) + i55;
                case 56: return PadStack(j - 1, a) + i56;
                case 57: return PadStack(j - 1, a) + i57;
                case 58: return PadStack(j - 1, a) + i58;
                case 59: return PadStack(j - 1, a) + i59;
                case 60: return PadStack(j - 1, a) + i60;
                case 61: return PadStack(j - 1, a) + i61;
                case 62: return PadStack(j - 1, a) + i62;
                case 63: return PadStack(j - 1, a) + i63;
                case 64: return PadStack(j - 1, a) + i64;
                case 65: return PadStack(j - 1, a) + i65;
                case 66: return PadStack(j - 1, a) + i66;
                case 67: return PadStack(j - 1, a) + i67;
                case 68: return PadStack(j - 1, a) + i68;
                case 69: return PadStack(j - 1, a) + i69;
                case 70: return PadStack(j - 1, a) + i70;
                case 71: return PadStack(j - 1, a) + i71;
                case 72: return PadStack(j - 1, a) + i72;
                case 73: return PadStack(j - 1, a) + i73;
                case 74: return PadStack(j - 1, a) + i74;
                case 75: return PadStack(j - 1, a) + i75;
                case 76: return PadStack(j - 1, a) + i76;
                case 77: return PadStack(j - 1, a) + i77;
                case 78: return PadStack(j - 1, a) + i78;
                case 79: return PadStack(j - 1, a) + i79;
                case 80: return PadStack(j - 1, a) + i80;
                case 81: return PadStack(j - 1, a) + i81;
                case 82: return PadStack(j - 1, a) + i82;
                case 83: return PadStack(j - 1, a) + i83;
                case 84: return PadStack(j - 1, a) + i84;
                case 85: return PadStack(j - 1, a) + i85;
                case 86: return PadStack(j - 1, a) + i86;
                case 87: return PadStack(j - 1, a) + i87;
                case 88: return PadStack(j - 1, a) + i88;
                case 89: return PadStack(j - 1, a) + i89;
                case 90: return PadStack(j - 1, a) + i90;
                case 91: return PadStack(j - 1, a) + i91;
                case 92: return PadStack(j - 1, a) + i92;
                case 93: return PadStack(j - 1, a) + i93;
                case 94: return PadStack(j - 1, a) + i94;
                case 95: return PadStack(j - 1, a) + i95;
                case 96: return PadStack(j - 1, a) + i96;
                case 97: return PadStack(j - 1, a) + i97;
                case 98: return PadStack(j - 1, a) + i98;
                default: case 99: return PadStack(j - 1, a) + i99;
            }
        }
    }
}
