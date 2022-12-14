using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectInsertSource : InsertSource, IEquatable<SelectInsertSource> {
        protected QueryExpression select;
    
        public QueryExpression Select => select;
    
        public SelectInsertSource(QueryExpression select = null) {
            this.select = select;
        }
    
        public ScriptDom.SelectInsertSource ToMutableConcrete() {
            var ret = new ScriptDom.SelectInsertSource();
            ret.Select = (ScriptDom.QueryExpression)select?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(select is null)) {
                h = h * 23 + select.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectInsertSource);
        } 
        
        public bool Equals(SelectInsertSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.Select, select)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectInsertSource left, SelectInsertSource right) {
            return EqualityComparer<SelectInsertSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectInsertSource left, SelectInsertSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectInsertSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.select, othr.select);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SelectInsertSource left, SelectInsertSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectInsertSource left, SelectInsertSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectInsertSource left, SelectInsertSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectInsertSource left, SelectInsertSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SelectInsertSource FromMutable(ScriptDom.SelectInsertSource fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SelectInsertSource)) { throw new NotImplementedException("Unexpected subtype of SelectInsertSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectInsertSource(
                select: ImmutableDom.QueryExpression.FromMutable(fragment.Select)
            );
        }
    
    }

}
