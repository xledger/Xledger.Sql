using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CompositeGroupingSpecification : GroupingSpecification, IEquatable<CompositeGroupingSpecification> {
        IReadOnlyList<GroupingSpecification> items;
    
        public IReadOnlyList<GroupingSpecification> Items => items;
    
        public CompositeGroupingSpecification(IReadOnlyList<GroupingSpecification> items = null) {
            this.items = items is null ? ImmList<GroupingSpecification>.Empty : ImmList<GroupingSpecification>.FromList(items);
        }
    
        public ScriptDom.CompositeGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.CompositeGroupingSpecification();
            ret.Items.AddRange(items.Select(c => (ScriptDom.GroupingSpecification)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + items.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CompositeGroupingSpecification);
        } 
        
        public bool Equals(CompositeGroupingSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<GroupingSpecification>>.Default.Equals(other.Items, items)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CompositeGroupingSpecification left, CompositeGroupingSpecification right) {
            return EqualityComparer<CompositeGroupingSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CompositeGroupingSpecification left, CompositeGroupingSpecification right) {
            return !(left == right);
        }
    
    }

}
