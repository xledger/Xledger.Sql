using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TargetRecoveryTimeDatabaseOption : DatabaseOption, IEquatable<TargetRecoveryTimeDatabaseOption> {
        protected Literal recoveryTime;
        protected ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds;
    
        public Literal RecoveryTime => recoveryTime;
        public ScriptDom.TimeUnit Unit => unit;
    
        public TargetRecoveryTimeDatabaseOption(Literal recoveryTime = null, ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.recoveryTime = recoveryTime;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.TargetRecoveryTimeDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.TargetRecoveryTimeDatabaseOption();
            ret.RecoveryTime = (ScriptDom.Literal)recoveryTime?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TargetRecoveryTimeDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.recoveryTime, othr.recoveryTime);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unit, othr.unit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TargetRecoveryTimeDatabaseOption left, TargetRecoveryTimeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TargetRecoveryTimeDatabaseOption FromMutable(ScriptDom.TargetRecoveryTimeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TargetRecoveryTimeDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of TargetRecoveryTimeDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TargetRecoveryTimeDatabaseOption(
                recoveryTime: ImmutableDom.Literal.FromMutable(fragment.RecoveryTime),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
