using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WithinGroupClause : TSqlFragment, IEquatable<WithinGroupClause> {
        protected OrderByClause orderByClause;
        protected bool hasGraphPath = false;
    
        public OrderByClause OrderByClause => orderByClause;
        public bool HasGraphPath => hasGraphPath;
    
        public WithinGroupClause(OrderByClause orderByClause = null, bool hasGraphPath = false) {
            this.orderByClause = orderByClause;
            this.hasGraphPath = hasGraphPath;
        }
    
        public ScriptDom.WithinGroupClause ToMutableConcrete() {
            var ret = new ScriptDom.WithinGroupClause();
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause.ToMutable();
            ret.HasGraphPath = hasGraphPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(orderByClause is null)) {
                h = h * 23 + orderByClause.GetHashCode();
            }
            h = h * 23 + hasGraphPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WithinGroupClause);
        } 
        
        public bool Equals(WithinGroupClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<OrderByClause>.Default.Equals(other.OrderByClause, orderByClause)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.HasGraphPath, hasGraphPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WithinGroupClause left, WithinGroupClause right) {
            return EqualityComparer<WithinGroupClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WithinGroupClause left, WithinGroupClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WithinGroupClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.orderByClause, othr.orderByClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.hasGraphPath, othr.hasGraphPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (WithinGroupClause left, WithinGroupClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WithinGroupClause left, WithinGroupClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WithinGroupClause left, WithinGroupClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WithinGroupClause left, WithinGroupClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
