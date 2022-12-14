using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GroupByClause : TSqlFragment, IEquatable<GroupByClause> {
        protected ScriptDom.GroupByOption groupByOption = ScriptDom.GroupByOption.None;
        protected bool all = false;
        protected IReadOnlyList<GroupingSpecification> groupingSpecifications;
    
        public ScriptDom.GroupByOption GroupByOption => groupByOption;
        public bool All => all;
        public IReadOnlyList<GroupingSpecification> GroupingSpecifications => groupingSpecifications;
    
        public GroupByClause(ScriptDom.GroupByOption groupByOption = ScriptDom.GroupByOption.None, bool all = false, IReadOnlyList<GroupingSpecification> groupingSpecifications = null) {
            this.groupByOption = groupByOption;
            this.all = all;
            this.groupingSpecifications = ImmList<GroupingSpecification>.FromList(groupingSpecifications);
        }
    
        public ScriptDom.GroupByClause ToMutableConcrete() {
            var ret = new ScriptDom.GroupByClause();
            ret.GroupByOption = groupByOption;
            ret.All = all;
            ret.GroupingSpecifications.AddRange(groupingSpecifications.SelectList(c => (ScriptDom.GroupingSpecification)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + groupByOption.GetHashCode();
            h = h * 23 + all.GetHashCode();
            h = h * 23 + groupingSpecifications.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GroupByClause);
        } 
        
        public bool Equals(GroupByClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.GroupByOption>.Default.Equals(other.GroupByOption, groupByOption)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<GroupingSpecification>>.Default.Equals(other.GroupingSpecifications, groupingSpecifications)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GroupByClause left, GroupByClause right) {
            return EqualityComparer<GroupByClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GroupByClause left, GroupByClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GroupByClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.groupByOption, othr.groupByOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.groupingSpecifications, othr.groupingSpecifications);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GroupByClause left, GroupByClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GroupByClause left, GroupByClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GroupByClause left, GroupByClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GroupByClause left, GroupByClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GroupByClause FromMutable(ScriptDom.GroupByClause fragment) {
            return (GroupByClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
