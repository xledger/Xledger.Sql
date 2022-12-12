using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GroupingSetsGroupingSpecification : GroupingSpecification, IEquatable<GroupingSetsGroupingSpecification> {
        protected IReadOnlyList<GroupingSpecification> sets;
    
        public IReadOnlyList<GroupingSpecification> Sets => sets;
    
        public GroupingSetsGroupingSpecification(IReadOnlyList<GroupingSpecification> sets = null) {
            this.sets = sets is null ? ImmList<GroupingSpecification>.Empty : ImmList<GroupingSpecification>.FromList(sets);
        }
    
        public ScriptDom.GroupingSetsGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.GroupingSetsGroupingSpecification();
            ret.Sets.AddRange(sets.SelectList(c => (ScriptDom.GroupingSpecification)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sets.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GroupingSetsGroupingSpecification);
        } 
        
        public bool Equals(GroupingSetsGroupingSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<GroupingSpecification>>.Default.Equals(other.Sets, sets)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GroupingSetsGroupingSpecification left, GroupingSetsGroupingSpecification right) {
            return EqualityComparer<GroupingSetsGroupingSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GroupingSetsGroupingSpecification left, GroupingSetsGroupingSpecification right) {
            return !(left == right);
        }
    
    }

}
