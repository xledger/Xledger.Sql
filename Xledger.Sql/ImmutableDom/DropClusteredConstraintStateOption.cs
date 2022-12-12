using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintStateOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintStateOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public DropClusteredConstraintStateOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintStateOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintStateOption();
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
            return Equals(obj as DropClusteredConstraintStateOption);
        } 
        
        public bool Equals(DropClusteredConstraintStateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropClusteredConstraintOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) {
            return EqualityComparer<DropClusteredConstraintStateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) {
            return !(left == right);
        }
    
    }

}
