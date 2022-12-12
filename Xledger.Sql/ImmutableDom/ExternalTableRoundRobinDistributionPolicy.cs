using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableRoundRobinDistributionPolicy : ExternalTableDistributionPolicy, IEquatable<ExternalTableRoundRobinDistributionPolicy> {
        public ExternalTableRoundRobinDistributionPolicy() {

        }
    
        public ScriptDom.ExternalTableRoundRobinDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableRoundRobinDistributionPolicy();
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
            return Equals(obj as ExternalTableRoundRobinDistributionPolicy);
        } 
        
        public bool Equals(ExternalTableRoundRobinDistributionPolicy other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(ExternalTableRoundRobinDistributionPolicy left, ExternalTableRoundRobinDistributionPolicy right) {
            return EqualityComparer<ExternalTableRoundRobinDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableRoundRobinDistributionPolicy left, ExternalTableRoundRobinDistributionPolicy right) {
            return !(left == right);
        }
    
    }

}
