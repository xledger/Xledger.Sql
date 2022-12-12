using Microsoft.SqlServer.TransactSql.ScriptDom;
using Xunit;

namespace Xledger.Sql.Test {
    public class TestReplaceScalar {
        [Fact]
        public void TestReplace() {
            var colRef = new ColumnReferenceExpression {
                MultiPartIdentifier = new MultiPartIdentifier {
                    Identifiers = { 
                        new Identifier { Value = "a" }, 
                        new Identifier { Value = "number" }, 
                    },
                },
            };
            var intLit = new IntegerLiteral { Value = "123" };
            var eqExpr = new BooleanComparisonExpression {
                ComparisonType = BooleanComparisonType.Equals,
                FirstExpression = colRef,
                SecondExpression = intLit,
            };

            var newRef = new ColumnReferenceExpression {
                MultiPartIdentifier = new MultiPartIdentifier {
                    Identifiers = {
                        new Identifier { Value = "b" },
                        new Identifier { Value = "value" },
                    },
                },
            };

            var replaced = eqExpr.ReplaceScalar(colRef, newRef);
            Assert.True(replaced);
            Assert.Equal(newRef, eqExpr.FirstExpression);
            Assert.Equal(intLit, eqExpr.SecondExpression);
        }

        [Fact]
        public void TestNoReplace() {
            var colRef = new ColumnReferenceExpression {
                MultiPartIdentifier = new MultiPartIdentifier {
                    Identifiers = {
                        new Identifier { Value = "a" },
                        new Identifier { Value = "number" },
                    },
                },
            };
            var intLit = new IntegerLiteral { Value = "123" };
            var eqExpr = new BooleanComparisonExpression {
                ComparisonType = BooleanComparisonType.Equals,
                FirstExpression = colRef,
                SecondExpression = intLit,
            };

            var newRef = new ColumnReferenceExpression {
                MultiPartIdentifier = new MultiPartIdentifier {
                    Identifiers = {
                        new Identifier { Value = "b" },
                        new Identifier { Value = "value" },
                    },
                },
            };

            var replaced = eqExpr.ReplaceScalar(newRef, newRef);
            Assert.False(replaced);
            Assert.Equal(colRef, eqExpr.FirstExpression);
            Assert.Equal(intLit, eqExpr.SecondExpression);
        }
    }
}
