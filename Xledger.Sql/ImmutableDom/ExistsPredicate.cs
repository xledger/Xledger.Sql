using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExistsPredicate : BooleanExpression, IEquatable<ExistsPredicate> {
        protected ScalarSubquery subquery;
    
        public ScalarSubquery Subquery => subquery;
    
        public ExistsPredicate(ScalarSubquery subquery = null) {
            this.subquery = subquery;
        }
    
        public ScriptDom.ExistsPredicate ToMutableConcrete() {
            var ret = new ScriptDom.ExistsPredicate();
            ret.Subquery = (ScriptDom.ScalarSubquery)subquery.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(subquery is null)) {
                h = h * 23 + subquery.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExistsPredicate);
        } 
        
        public bool Equals(ExistsPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarSubquery>.Default.Equals(other.Subquery, subquery)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExistsPredicate left, ExistsPredicate right) {
            return EqualityComparer<ExistsPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExistsPredicate left, ExistsPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExistsPredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.subquery, othr.subquery);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ExistsPredicate left, ExistsPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExistsPredicate left, ExistsPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExistsPredicate left, ExistsPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExistsPredicate left, ExistsPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExistsPredicate FromMutable(ScriptDom.ExistsPredicate fragment) {
            return (ExistsPredicate)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
