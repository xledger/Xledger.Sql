using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OptimizedLockingDatabaseOption : DatabaseOption, IEquatable<OptimizedLockingDatabaseOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OptimizedLockingDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.OptimizedLockingDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.OptimizedLockingDatabaseOption();
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
            return Equals(obj as OptimizedLockingDatabaseOption);
        } 
        
        public bool Equals(OptimizedLockingDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) {
            return EqualityComparer<OptimizedLockingDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OptimizedLockingDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OptimizedLockingDatabaseOption left, OptimizedLockingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OptimizedLockingDatabaseOption FromMutable(ScriptDom.OptimizedLockingDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OptimizedLockingDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of OptimizedLockingDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OptimizedLockingDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
