using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderByClause : TSqlFragment, IEquatable<OrderByClause> {
        protected IReadOnlyList<ExpressionWithSortOrder> orderByElements;
    
        public IReadOnlyList<ExpressionWithSortOrder> OrderByElements => orderByElements;
    
        public OrderByClause(IReadOnlyList<ExpressionWithSortOrder> orderByElements = null) {
            this.orderByElements = ImmList<ExpressionWithSortOrder>.FromList(orderByElements);
        }
    
        public ScriptDom.OrderByClause ToMutableConcrete() {
            var ret = new ScriptDom.OrderByClause();
            ret.OrderByElements.AddRange(orderByElements.SelectList(c => (ScriptDom.ExpressionWithSortOrder)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + orderByElements.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OrderByClause);
        } 
        
        public bool Equals(OrderByClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ExpressionWithSortOrder>>.Default.Equals(other.OrderByElements, orderByElements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OrderByClause left, OrderByClause right) {
            return EqualityComparer<OrderByClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OrderByClause left, OrderByClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OrderByClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.orderByElements, othr.orderByElements);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
