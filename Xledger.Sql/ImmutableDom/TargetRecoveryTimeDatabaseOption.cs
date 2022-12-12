using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TargetRecoveryTimeDatabaseOption : DatabaseOption, IEquatable<TargetRecoveryTimeDatabaseOption> {
        Literal recoveryTime;
        ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds;
    
        public Literal RecoveryTime => recoveryTime;
        public ScriptDom.TimeUnit Unit => unit;
    
        public TargetRecoveryTimeDatabaseOption(Literal recoveryTime = null, ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.recoveryTime = recoveryTime;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TargetRecoveryTimeDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.TargetRecoveryTimeDatabaseOption();
            ret.RecoveryTime = (ScriptDom.Literal)recoveryTime.ToMutable();
            ret.Unit = unit;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(recoveryTime is null)) {
                h = h * 23 + recoveryTime.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TargetRecoveryTimeDatabaseOption);
        } 
        
        public bool Equals(TargetRecoveryTimeDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.RecoveryTime, recoveryTime)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TimeUnit>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) {
            return EqualityComparer<TargetRecoveryTimeDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
