using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffDialogOption : DialogOption, IEquatable<OnOffDialogOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffDialogOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DialogOptionKind optionKind = ScriptDom.DialogOptionKind.RelatedConversation) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffDialogOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffDialogOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnOffDialogOption);
        } 
        
        public bool Equals(OnOffDialogOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DialogOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffDialogOption left, OnOffDialogOption right) {
            return EqualityComparer<OnOffDialogOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffDialogOption left, OnOffDialogOption right) {
            return !(left == right);
        }
    
    }

}
