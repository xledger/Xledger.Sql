using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LedgerOption : DatabaseOption, IEquatable<LedgerOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public LedgerOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LedgerOption ToMutableConcrete() {
            var ret = new ScriptDom.LedgerOption();
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
            return Equals(obj as LedgerOption);
        } 
        
        public bool Equals(LedgerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LedgerOption left, LedgerOption right) {
            return EqualityComparer<LedgerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LedgerOption left, LedgerOption right) {
            return !(left == right);
        }
    
        public static LedgerOption FromMutable(ScriptDom.LedgerOption fragment) {
            return (LedgerOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
