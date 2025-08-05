using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GrandTotalGroupingSpecification : GroupingSpecification, IEquatable<GrandTotalGroupingSpecification> {
        public GrandTotalGroupingSpecification() {

        }
    
        public ScriptDom.GrandTotalGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.GrandTotalGroupingSpecification();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GrandTotalGroupingSpecification);
        } 
        
        public bool Equals(GrandTotalGroupingSpecification other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) {
            return EqualityComparer<GrandTotalGroupingSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GrandTotalGroupingSpecification)that;
            return compare;
        } 
        
        public static bool operator < (GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GrandTotalGroupingSpecification left, GrandTotalGroupingSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GrandTotalGroupingSpecification FromMutable(ScriptDom.GrandTotalGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GrandTotalGroupingSpecification)) { throw new NotImplementedException("Unexpected subtype of GrandTotalGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrandTotalGroupingSpecification(
                
            );
        }
    
    }

}
