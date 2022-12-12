using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QuerySpecification : QueryExpression, IEquatable<QuerySpecification> {
        ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified;
        TopRowFilter topRowFilter;
        IReadOnlyList<SelectElement> selectElements;
        FromClause fromClause;
        WhereClause whereClause;
        GroupByClause groupByClause;
        HavingClause havingClause;
        WindowClause windowClause;
    
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
            this.selectElements = selectElements is null ? ImmList<SelectElement>.Empty : ImmList<SelectElement>.FromList(selectElements);
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
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter.ToMutable();
            ret.SelectElements.AddRange(selectElements.Select(c => (ScriptDom.SelectElement)c.ToMutable()));
            ret.FromClause = (ScriptDom.FromClause)fromClause.ToMutable();
            ret.WhereClause = (ScriptDom.WhereClause)whereClause.ToMutable();
            ret.GroupByClause = (ScriptDom.GroupByClause)groupByClause.ToMutable();
            ret.HavingClause = (ScriptDom.HavingClause)havingClause.ToMutable();
            ret.WindowClause = (ScriptDom.WindowClause)windowClause.ToMutable();
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause.ToMutable();
            ret.OffsetClause = (ScriptDom.OffsetClause)offsetClause.ToMutable();
            ret.ForClause = (ScriptDom.ForClause)forClause.ToMutable();
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
    
    }

}
