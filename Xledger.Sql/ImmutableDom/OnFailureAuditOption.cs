using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnFailureAuditOption : AuditOption, IEquatable<OnFailureAuditOption> {
        ScriptDom.AuditFailureActionType onFailureAction = ScriptDom.AuditFailureActionType.Continue;
    
        public ScriptDom.AuditFailureActionType OnFailureAction => onFailureAction;
    
        public OnFailureAuditOption(ScriptDom.AuditFailureActionType onFailureAction = ScriptDom.AuditFailureActionType.Continue, ScriptDom.AuditOptionKind optionKind = ScriptDom.AuditOptionKind.QueueDelay) {
            this.onFailureAction = onFailureAction;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnFailureAuditOption ToMutableConcrete() {
            var ret = new ScriptDom.OnFailureAuditOption();
            ret.OnFailureAction = onFailureAction;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + onFailureAction.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnFailureAuditOption);
        } 
        
        public bool Equals(OnFailureAuditOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AuditFailureActionType>.Default.Equals(other.OnFailureAction, onFailureAction)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnFailureAuditOption left, OnFailureAuditOption right) {
            return EqualityComparer<OnFailureAuditOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnFailureAuditOption left, OnFailureAuditOption right) {
            return !(left == right);
        }
    
    }

}