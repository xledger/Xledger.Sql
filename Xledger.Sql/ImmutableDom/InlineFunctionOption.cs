using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InlineFunctionOption : FunctionOption, IEquatable<InlineFunctionOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public InlineFunctionOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.InlineFunctionOption ToMutableConcrete() {
            var ret = new ScriptDom.InlineFunctionOption();
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
            return Equals(obj as InlineFunctionOption);
        } 
        
        public bool Equals(InlineFunctionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FunctionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InlineFunctionOption left, InlineFunctionOption right) {
            return EqualityComparer<InlineFunctionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InlineFunctionOption left, InlineFunctionOption right) {
            return !(left == right);
        }
    
        public static InlineFunctionOption FromMutable(ScriptDom.InlineFunctionOption fragment) {
            return (InlineFunctionOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
