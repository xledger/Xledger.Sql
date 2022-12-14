using Xledger.Sql.ImmutableDom;
using Xunit;

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
    }
}
