using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderByClause : TSqlFragment, IEquatable<OrderByClause> {
        protected IReadOnlyList<ExpressionWithSortOrder> orderByElements;
        protected bool all = false;
        protected ScriptDom.SortOrder allSortOrder = ScriptDom.SortOrder.NotSpecified;
    
        public IReadOnlyList<ExpressionWithSortOrder> OrderByElements => orderByElements;
        public bool All => all;
        public ScriptDom.SortOrder AllSortOrder => allSortOrder;
    
        public OrderByClause(IReadOnlyList<ExpressionWithSortOrder> orderByElements = null, bool all = false, ScriptDom.SortOrder allSortOrder = ScriptDom.SortOrder.NotSpecified) {
            this.orderByElements = orderByElements.ToImmArray<ExpressionWithSortOrder>();
            this.all = all;
            this.allSortOrder = allSortOrder;
        }
    
        public ScriptDom.OrderByClause ToMutableConcrete() {
            var ret = new ScriptDom.OrderByClause();
            ret.OrderByElements.AddRange(orderByElements.Select(c => (ScriptDom.ExpressionWithSortOrder)c?.ToMutable()));
            ret.All = all;
            ret.AllSortOrder = allSortOrder;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + orderByElements.GetHashCode();
            h = h * 23 + all.GetHashCode();
            h = h * 23 + allSortOrder.GetHashCode();
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
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SortOrder>.Default.Equals(other.AllSortOrder, allSortOrder)) {
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
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.allSortOrder, othr.allSortOrder);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OrderByClause left, OrderByClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OrderByClause FromMutable(ScriptDom.OrderByClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OrderByClause)) { throw new NotImplementedException("Unexpected subtype of OrderByClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderByClause(
                orderByElements: fragment.OrderByElements.ToImmArray(ImmutableDom.ExpressionWithSortOrder.FromMutable),
                all: fragment.All,
                allSortOrder: fragment.AllSortOrder
            );
        }
    
    }

}
