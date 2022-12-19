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
    
        public new ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption ToMutableConcrete() {
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AcceleratedDatabaseRecoveryDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AcceleratedDatabaseRecoveryDatabaseOption left, AcceleratedDatabaseRecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AcceleratedDatabaseRecoveryDatabaseOption FromMutable(ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of AcceleratedDatabaseRecoveryDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AcceleratedDatabaseRecoveryDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
