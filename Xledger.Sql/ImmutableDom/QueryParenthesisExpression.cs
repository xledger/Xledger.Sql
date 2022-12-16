using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryParenthesisExpression : QueryExpression, IEquatable<QueryParenthesisExpression> {
        protected QueryExpression queryExpression;
    
        public QueryExpression QueryExpression => queryExpression;
    
        public QueryParenthesisExpression(QueryExpression queryExpression = null, OrderByClause orderByClause = null, OffsetClause offsetClause = null, ForClause forClause = null) {
            this.queryExpression = queryExpression;
            this.orderByClause = orderByClause;
            this.offsetClause = offsetClause;
            this.forClause = forClause;
        }
    
        public ScriptDom.QueryParenthesisExpression ToMutableConcrete() {
            var ret = new ScriptDom.QueryParenthesisExpression();
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression?.ToMutable();
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause?.ToMutable();
            ret.OffsetClause = (ScriptDom.OffsetClause)offsetClause?.ToMutable();
            ret.ForClause = (ScriptDom.ForClause)forClause?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(queryExpression is null)) {
                h = h * 23 + queryExpression.GetHashCode();
            }
            if (!(orderByClause is null)) {
                h = h * 23 + orderByClause.GetHashCode();
            }
            if (!(offsetClause is null)) {
                h = h * 23 + offsetClause.GetHashCode();
            }
            if (!(forClause is null)) {
                h = h * 23 + forClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryParenthesisExpression);
        } 
        
        public bool Equals(QueryParenthesisExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.QueryExpression, queryExpression)) {
                return false;
            }
            if (!EqualityComparer<OrderByClause>.Default.Equals(other.OrderByClause, orderByClause)) {
                return false;
            }
            if (!EqualityComparer<OffsetClause>.Default.Equals(other.OffsetClause, offsetClause)) {
                return false;
            }
            if (!EqualityComparer<ForClause>.Default.Equals(other.ForClause, forClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryParenthesisExpression left, QueryParenthesisExpression right) {
            return EqualityComparer<QueryParenthesisExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryParenthesisExpression left, QueryParenthesisExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryParenthesisExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.queryExpression, othr.queryExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.orderByClause, othr.orderByClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.offsetClause, othr.offsetClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forClause, othr.forClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (QueryParenthesisExpression left, QueryParenthesisExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryParenthesisExpression left, QueryParenthesisExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryParenthesisExpression left, QueryParenthesisExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryParenthesisExpression left, QueryParenthesisExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
