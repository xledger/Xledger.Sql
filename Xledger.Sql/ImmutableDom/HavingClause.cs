using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class HavingClause : TSqlFragment, IEquatable<HavingClause> {
        protected BooleanExpression searchCondition;
    
        public BooleanExpression SearchCondition => searchCondition;
    
        public HavingClause(BooleanExpression searchCondition = null) {
            this.searchCondition = searchCondition;
        }
    
        public ScriptDom.HavingClause ToMutableConcrete() {
            var ret = new ScriptDom.HavingClause();
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as HavingClause);
        } 
        
        public bool Equals(HavingClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(HavingClause left, HavingClause right) {
            return EqualityComparer<HavingClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(HavingClause left, HavingClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (HavingClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.searchCondition, othr.searchCondition);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (HavingClause left, HavingClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(HavingClause left, HavingClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (HavingClause left, HavingClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(HavingClause left, HavingClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static HavingClause FromMutable(ScriptDom.HavingClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.HavingClause)) { throw new NotImplementedException("Unexpected subtype of HavingClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new HavingClause(
                searchCondition: ImmutableDom.BooleanExpression.FromMutable(fragment.SearchCondition)
            );
        }
    
    }

}
