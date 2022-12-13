using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StateAuditOption : AuditOption, IEquatable<StateAuditOption> {
        protected ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState Value => @value;
    
        public StateAuditOption(ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet, ScriptDom.AuditOptionKind optionKind = ScriptDom.AuditOptionKind.QueueDelay) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.StateAuditOption ToMutableConcrete() {
            var ret = new ScriptDom.StateAuditOption();
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
            return Equals(obj as StateAuditOption);
        } 
        
        public bool Equals(StateAuditOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StateAuditOption left, StateAuditOption right) {
            return EqualityComparer<StateAuditOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StateAuditOption left, StateAuditOption right) {
            return !(left == right);
        }
    
        public static StateAuditOption FromMutable(ScriptDom.StateAuditOption fragment) {
            return (StateAuditOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
