using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffAtomicBlockOption : AtomicBlockOption, IEquatable<OnOffAtomicBlockOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffAtomicBlockOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.AtomicBlockOptionKind optionKind = ScriptDom.AtomicBlockOptionKind.IsolationLevel) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffAtomicBlockOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffAtomicBlockOption();
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
            return Equals(obj as OnOffAtomicBlockOption);
        } 
        
        public bool Equals(OnOffAtomicBlockOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AtomicBlockOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffAtomicBlockOption left, OnOffAtomicBlockOption right) {
            return EqualityComparer<OnOffAtomicBlockOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffAtomicBlockOption left, OnOffAtomicBlockOption right) {
            return !(left == right);
        }
    
    }

}