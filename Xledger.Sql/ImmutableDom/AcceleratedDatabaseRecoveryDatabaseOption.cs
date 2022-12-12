using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AcceleratedDatabaseRecoveryDatabaseOption : DatabaseOption, IEquatable<AcceleratedDatabaseRecoveryDatabaseOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public AcceleratedDatabaseRecoveryDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption();
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
            return Equals(obj as AcceleratedDatabaseRecoveryDatabaseOption);
        } 
        
        public bool Equals(AcceleratedDatabaseRecoveryDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) {
            return EqualityComparer<AcceleratedDatabaseRecoveryDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
