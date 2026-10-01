using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VectorSearchTableReference : TableReferenceWithAlias, IEquatable<VectorSearchTableReference> {
        protected TableReferenceWithAlias table;
        protected ColumnReferenceExpression column;
        protected ScalarExpression similarTo;
        protected StringLiteral metric;
        protected ScalarExpression topN;
        protected bool forceAnnOnly = false;
    
        public TableReferenceWithAlias Table => table;
        public ColumnReferenceExpression Column => column;
        public ScalarExpression SimilarTo => similarTo;
        public StringLiteral Metric => metric;
        public ScalarExpression TopN => topN;
        public bool ForceAnnOnly => forceAnnOnly;
    
        public VectorSearchTableReference(TableReferenceWithAlias table = null, ColumnReferenceExpression column = null, ScalarExpression similarTo = null, StringLiteral metric = null, ScalarExpression topN = null, bool forceAnnOnly = false, Identifier alias = null, bool forPath = false) {
            this.table = table;
            this.column = column;
            this.similarTo = similarTo;
            this.metric = metric;
            this.topN = topN;
            this.forceAnnOnly = forceAnnOnly;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.VectorSearchTableReference ToMutableConcrete() {
            var ret = new ScriptDom.VectorSearchTableReference();
            ret.Table = (ScriptDom.TableReferenceWithAlias)table?.ToMutable();
            ret.Column = (ScriptDom.ColumnReferenceExpression)column?.ToMutable();
            ret.SimilarTo = (ScriptDom.ScalarExpression)similarTo?.ToMutable();
            ret.Metric = (ScriptDom.StringLiteral)metric?.ToMutable();
            ret.TopN = (ScriptDom.ScalarExpression)topN?.ToMutable();
            ret.ForceAnnOnly = forceAnnOnly;
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(table is null)) {
                h = h * 23 + table.GetHashCode();
            }
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            if (!(similarTo is null)) {
                h = h * 23 + similarTo.GetHashCode();
            }
            if (!(metric is null)) {
                h = h * 23 + metric.GetHashCode();
            }
            if (!(topN is null)) {
                h = h * 23 + topN.GetHashCode();
            }
            h = h * 23 + forceAnnOnly.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VectorSearchTableReference);
        } 
        
        public bool Equals(VectorSearchTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReferenceWithAlias>.Default.Equals(other.Table, table)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SimilarTo, similarTo)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Metric, metric)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.TopN, topN)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForceAnnOnly, forceAnnOnly)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VectorSearchTableReference left, VectorSearchTableReference right) {
            return EqualityComparer<VectorSearchTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VectorSearchTableReference left, VectorSearchTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VectorSearchTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.table, othr.table);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.column, othr.column);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.similarTo, othr.similarTo);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.metric, othr.metric);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.topN, othr.topN);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forceAnnOnly, othr.forceAnnOnly);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (VectorSearchTableReference left, VectorSearchTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VectorSearchTableReference left, VectorSearchTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VectorSearchTableReference left, VectorSearchTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VectorSearchTableReference left, VectorSearchTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VectorSearchTableReference FromMutable(ScriptDom.VectorSearchTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.VectorSearchTableReference)) { throw new NotImplementedException("Unexpected subtype of VectorSearchTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VectorSearchTableReference(
                table: ImmutableDom.TableReferenceWithAlias.FromMutable(fragment.Table),
                column: ImmutableDom.ColumnReferenceExpression.FromMutable(fragment.Column),
                similarTo: ImmutableDom.ScalarExpression.FromMutable(fragment.SimilarTo),
                metric: ImmutableDom.StringLiteral.FromMutable(fragment.Metric),
                topN: ImmutableDom.ScalarExpression.FromMutable(fragment.TopN),
                forceAnnOnly: fragment.ForceAnnOnly,
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
