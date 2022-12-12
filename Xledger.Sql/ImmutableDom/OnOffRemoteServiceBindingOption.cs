using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffRemoteServiceBindingOption : RemoteServiceBindingOption, IEquatable<OnOffRemoteServiceBindingOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffRemoteServiceBindingOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.RemoteServiceBindingOptionKind optionKind = ScriptDom.RemoteServiceBindingOptionKind.User) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffRemoteServiceBindingOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffRemoteServiceBindingOption();
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
            return Equals(obj as OnOffRemoteServiceBindingOption);
        } 
        
        public bool Equals(OnOffRemoteServiceBindingOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteServiceBindingOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffRemoteServiceBindingOption left, OnOffRemoteServiceBindingOption right) {
            return EqualityComparer<OnOffRemoteServiceBindingOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffRemoteServiceBindingOption left, OnOffRemoteServiceBindingOption right) {
            return !(left == right);
        }
    
    }

}
