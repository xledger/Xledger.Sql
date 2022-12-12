using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AvailabilityModeReplicaOption : AvailabilityReplicaOption, IEquatable<AvailabilityModeReplicaOption> {
        protected ScriptDom.AvailabilityModeOptionKind @value = ScriptDom.AvailabilityModeOptionKind.SynchronousCommit;
    
        public ScriptDom.AvailabilityModeOptionKind Value => @value;
    
        public AvailabilityModeReplicaOption(ScriptDom.AvailabilityModeOptionKind @value = ScriptDom.AvailabilityModeOptionKind.SynchronousCommit, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AvailabilityModeReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.AvailabilityModeReplicaOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AvailabilityModeReplicaOption);
        } 
        
        public bool Equals(AvailabilityModeReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AvailabilityModeOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AvailabilityModeReplicaOption left, AvailabilityModeReplicaOption right) {
            return EqualityComparer<AvailabilityModeReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AvailabilityModeReplicaOption left, AvailabilityModeReplicaOption right) {
            return !(left == right);
        }
    
    }

}
