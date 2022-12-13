using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
    
        public static GrandTotalGroupingSpecification FromMutable(ScriptDom.GrandTotalGroupingSpecification fragment) {
            return (GrandTotalGroupingSpecification)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
