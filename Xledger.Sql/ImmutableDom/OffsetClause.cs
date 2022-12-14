using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OffsetClause : TSqlFragment, IEquatable<OffsetClause> {
        protected ScalarExpression offsetExpression;
        protected ScalarExpression fetchExpression;
    
        public ScalarExpression OffsetExpression => offsetExpression;
        public ScalarExpression FetchExpression => fetchExpression;
    
        public OffsetClause(ScalarExpression offsetExpression = null, ScalarExpression fetchExpression = null) {
            this.offsetExpression = offsetExpression;
            this.fetchExpression = fetchExpression;
        }
    
        public ScriptDom.OffsetClause ToMutableConcrete() {
            var ret = new ScriptDom.OffsetClause();
            ret.OffsetExpression = (ScriptDom.ScalarExpression)offsetExpression.ToMutable();
            ret.FetchExpression = (ScriptDom.ScalarExpression)fetchExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(offsetExpression is null)) {
                h = h * 23 + offsetExpression.GetHashCode();
            }
            if (!(fetchExpression is null)) {
                h = h * 23 + fetchExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OffsetClause);
        } 
        
        public bool Equals(OffsetClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.OffsetExpression, offsetExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FetchExpression, fetchExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OffsetClause left, OffsetClause right) {
            return EqualityComparer<OffsetClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OffsetClause left, OffsetClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OffsetClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.offsetExpression, othr.offsetExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fetchExpression, othr.fetchExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OffsetClause left, OffsetClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OffsetClause left, OffsetClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OffsetClause left, OffsetClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OffsetClause left, OffsetClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OffsetClause FromMutable(ScriptDom.OffsetClause fragment) {
            return (OffsetClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
