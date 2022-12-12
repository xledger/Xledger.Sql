using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewRoundRobinDistributionPolicy : ViewDistributionPolicy, IEquatable<ViewRoundRobinDistributionPolicy> {
        public ViewRoundRobinDistributionPolicy() {

        }
    
        public ScriptDom.ViewRoundRobinDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.ViewRoundRobinDistributionPolicy();
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
            return Equals(obj as ViewRoundRobinDistributionPolicy);
        } 
        
        public bool Equals(ViewRoundRobinDistributionPolicy other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(ViewRoundRobinDistributionPolicy left, ViewRoundRobinDistributionPolicy right) {
            return EqualityComparer<ViewRoundRobinDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewRoundRobinDistributionPolicy left, ViewRoundRobinDistributionPolicy right) {
            return !(left == right);
        }
    
    }

}