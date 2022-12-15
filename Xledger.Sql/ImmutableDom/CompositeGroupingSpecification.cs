using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CompositeGroupingSpecification : GroupingSpecification, IEquatable<CompositeGroupingSpecification> {
        protected IReadOnlyList<GroupingSpecification> items;
    
        public IReadOnlyList<GroupingSpecification> Items => items;
    
        public CompositeGroupingSpecification(IReadOnlyList<GroupingSpecification> items = null) {
            this.items = ImmList<GroupingSpecification>.FromList(items);
        }
    
        public ScriptDom.CompositeGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.CompositeGroupingSpecification();
            ret.Items.AddRange(items.SelectList(c => (ScriptDom.GroupingSpecification)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CompositeGroupingSpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.items, othr.items);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CompositeGroupingSpecification left, CompositeGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CompositeGroupingSpecification left, CompositeGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CompositeGroupingSpecification left, CompositeGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CompositeGroupingSpecification left, CompositeGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
