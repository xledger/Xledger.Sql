using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PrimaryRoleReplicaOption : AvailabilityReplicaOption, IEquatable<PrimaryRoleReplicaOption> {
        ScriptDom.AllowConnectionsOptionKind allowConnections = ScriptDom.AllowConnectionsOptionKind.No;
    
        public ScriptDom.AllowConnectionsOptionKind AllowConnections => allowConnections;
    
        public PrimaryRoleReplicaOption(ScriptDom.AllowConnectionsOptionKind allowConnections = ScriptDom.AllowConnectionsOptionKind.No, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.allowConnections = allowConnections;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.PrimaryRoleReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.PrimaryRoleReplicaOption();
            ret.AllowConnections = allowConnections;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + allowConnections.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PrimaryRoleReplicaOption);
        } 
        
        public bool Equals(PrimaryRoleReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AllowConnectionsOptionKind>.Default.Equals(other.AllowConnections, allowConnections)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PrimaryRoleReplicaOption left, PrimaryRoleReplicaOption right) {
            return EqualityComparer<PrimaryRoleReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PrimaryRoleReplicaOption left, PrimaryRoleReplicaOption right) {
            return !(left == right);
        }
    
    }

}
