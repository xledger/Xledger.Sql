using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QuerySpecification : QueryExpression, IEquatable<QuerySpecification> {
        protected ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified;
        protected TopRowFilter topRowFilter;
        protected IReadOnlyList<SelectElement> selectElements;
        protected FromClause fromClause;
        protected WhereClause whereClause;
        protected GroupByClause groupByClause;
        protected HavingClause havingClause;
        protected WindowClause windowClause;
    
        public ScriptDom.UniqueRowFilter UniqueRowFilter => uniqueRowFilter;
        public TopRowFilter TopRowFilter => topRowFilter;
        public IReadOnlyList<SelectElement> SelectElements => selectElements;
        public FromClause FromClause => fromClause;
        public WhereClause WhereClause => whereClause;
        public GroupByClause GroupByClause => groupByClause;
        public HavingClause HavingClause => havingClause;
        public WindowClause WindowClause => windowClause;
    
        public QuerySpecification(ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified, TopRowFilter topRowFilter = null, IReadOnlyList<SelectElement> selectElements = null, FromClause fromClause = null, WhereClause whereClause = null, GroupByClause groupByClause = null, HavingClause havingClause = null, WindowClause windowClause = null, OrderByClause orderByClause = null, OffsetClause offsetClause = null, ForClause forClause = null) {
            this.uniqueRowFilter = uniqueRowFilter;
            this.topRowFilter = topRowFilter;
            this.selectElements = ImmList<SelectElement>.FromList(selectElements);
            this.fromClause = fromClause;
            this.whereClause = whereClause;
            this.groupByClause = groupByClause;
            this.havingClause = havingClause;
            this.windowClause = windowClause;
            this.orderByClause = orderByClause;
            this.offsetClause = offsetClause;
            this.forClause = forClause;
        }
    
        public ScriptDom.QuerySpecification ToMutableConcrete() {
            var ret = new ScriptDom.QuerySpecification();
            ret.UniqueRowFilter = uniqueRowFilter;
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter?.ToMutable();
            ret.SelectElements.AddRange(selectElements.SelectList(c => (ScriptDom.SelectElement)c?.ToMutable()));
            ret.FromClause = (ScriptDom.FromClause)fromClause?.ToMutable();
            ret.WhereClause = (ScriptDom.WhereClause)whereClause?.ToMutable();
            ret.GroupByClause = (ScriptDom.GroupByClause)groupByClause?.ToMutable();
            ret.HavingClause = (ScriptDom.HavingClause)havingClause?.ToMutable();
            ret.WindowClause = (ScriptDom.WindowClause)windowClause?.ToMutable();
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
            h = h * 23 + uniqueRowFilter.GetHashCode();
            if (!(topRowFilter is null)) {
                h = h * 23 + topRowFilter.GetHashCode();
            }
            h = h * 23 + selectElements.GetHashCode();
            if (!(fromClause is null)) {
                h = h * 23 + fromClause.GetHashCode();
            }
            if (!(whereClause is null)) {
                h = h * 23 + whereClause.GetHashCode();
            }
            if (!(groupByClause is null)) {
                h = h * 23 + groupByClause.GetHashCode();
            }
            if (!(havingClause is null)) {
                h = h * 23 + havingClause.GetHashCode();
            }
            if (!(windowClause is null)) {
                h = h * 23 + windowClause.GetHashCode();
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
            return Equals(obj as QuerySpecification);
        } 
        
        public bool Equals(QuerySpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.UniqueRowFilter>.Default.Equals(other.UniqueRowFilter, uniqueRowFilter)) {
                return false;
            }
            if (!EqualityComparer<TopRowFilter>.Default.Equals(other.TopRowFilter, topRowFilter)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SelectElement>>.Default.Equals(other.SelectElements, selectElements)) {
                return false;
            }
            if (!EqualityComparer<FromClause>.Default.Equals(other.FromClause, fromClause)) {
                return false;
            }
            if (!EqualityComparer<WhereClause>.Default.Equals(other.WhereClause, whereClause)) {
                return false;
            }
            if (!EqualityComparer<GroupByClause>.Default.Equals(other.GroupByClause, groupByClause)) {
                return false;
            }
            if (!EqualityComparer<HavingClause>.Default.Equals(other.HavingClause, havingClause)) {
                return false;
            }
            if (!EqualityComparer<WindowClause>.Default.Equals(other.WindowClause, windowClause)) {
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
        
        public static bool operator ==(QuerySpecification left, QuerySpecification right) {
            return EqualityComparer<QuerySpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QuerySpecification left, QuerySpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QuerySpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.uniqueRowFilter, othr.uniqueRowFilter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.topRowFilter, othr.topRowFilter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.selectElements, othr.selectElements);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fromClause, othr.fromClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.whereClause, othr.whereClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.groupByClause, othr.groupByClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.havingClause, othr.havingClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.windowClause, othr.windowClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.orderByClause, othr.orderByClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.offsetClause, othr.offsetClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forClause, othr.forClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QuerySpecification left, QuerySpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QuerySpecification left, QuerySpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QuerySpecification left, QuerySpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QuerySpecification left, QuerySpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QuerySpecification FromMutable(ScriptDom.QuerySpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QuerySpecification)) { throw new NotImplementedException("Unexpected subtype of QuerySpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QuerySpecification(
                uniqueRowFilter: fragment.UniqueRowFilter,
                topRowFilter: ImmutableDom.TopRowFilter.FromMutable(fragment.TopRowFilter),
                selectElements: fragment.SelectElements.SelectList(ImmutableDom.SelectElement.FromMutable),
                fromClause: ImmutableDom.FromClause.FromMutable(fragment.FromClause),
                whereClause: ImmutableDom.WhereClause.FromMutable(fragment.WhereClause),
                groupByClause: ImmutableDom.GroupByClause.FromMutable(fragment.GroupByClause),
                havingClause: ImmutableDom.HavingClause.FromMutable(fragment.HavingClause),
                windowClause: ImmutableDom.WindowClause.FromMutable(fragment.WindowClause),
                orderByClause: ImmutableDom.OrderByClause.FromMutable(fragment.OrderByClause),
                offsetClause: ImmutableDom.OffsetClause.FromMutable(fragment.OffsetClause),
                forClause: ImmutableDom.ForClause.FromMutable(fragment.ForClause)
            );
        }
    
    }

}
