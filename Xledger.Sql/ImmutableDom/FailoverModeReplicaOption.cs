using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FailoverModeReplicaOption : AvailabilityReplicaOption, IEquatable<FailoverModeReplicaOption> {
        ScriptDom.FailoverModeOptionKind @value = ScriptDom.FailoverModeOptionKind.Automatic;
    
        public ScriptDom.FailoverModeOptionKind Value => @value;
    
        public FailoverModeReplicaOption(ScriptDom.FailoverModeOptionKind @value = ScriptDom.FailoverModeOptionKind.Automatic, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FailoverModeReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.FailoverModeReplicaOption();
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
            return Equals(obj as FailoverModeReplicaOption);
        } 
        
        public bool Equals(FailoverModeReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FailoverModeOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FailoverModeReplicaOption left, FailoverModeReplicaOption right) {
            return EqualityComparer<FailoverModeReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FailoverModeReplicaOption left, FailoverModeReplicaOption right) {
            return !(left == right);
        }
    
    }

}
