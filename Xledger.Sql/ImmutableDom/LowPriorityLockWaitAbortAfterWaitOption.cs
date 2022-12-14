using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LowPriorityLockWaitAbortAfterWaitOption : LowPriorityLockWaitOption, IEquatable<LowPriorityLockWaitAbortAfterWaitOption> {
        protected ScriptDom.AbortAfterWaitType abortAfterWait = ScriptDom.AbortAfterWaitType.None;
    
        public ScriptDom.AbortAfterWaitType AbortAfterWait => abortAfterWait;
    
        public LowPriorityLockWaitAbortAfterWaitOption(ScriptDom.AbortAfterWaitType abortAfterWait = ScriptDom.AbortAfterWaitType.None, ScriptDom.LowPriorityLockWaitOptionKind optionKind = ScriptDom.LowPriorityLockWaitOptionKind.MaxDuration) {
            this.abortAfterWait = abortAfterWait;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LowPriorityLockWaitAbortAfterWaitOption ToMutableConcrete() {
            var ret = new ScriptDom.LowPriorityLockWaitAbortAfterWaitOption();
            ret.AbortAfterWait = abortAfterWait;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + abortAfterWait.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LowPriorityLockWaitAbortAfterWaitOption);
        } 
        
        public bool Equals(LowPriorityLockWaitAbortAfterWaitOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AbortAfterWaitType>.Default.Equals(other.AbortAfterWait, abortAfterWait)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.LowPriorityLockWaitOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) {
            return EqualityComparer<LowPriorityLockWaitAbortAfterWaitOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LowPriorityLockWaitAbortAfterWaitOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.abortAfterWait, othr.abortAfterWait);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LowPriorityLockWaitAbortAfterWaitOption left, LowPriorityLockWaitAbortAfterWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static LowPriorityLockWaitAbortAfterWaitOption FromMutable(ScriptDom.LowPriorityLockWaitAbortAfterWaitOption fragment) {
            return (LowPriorityLockWaitAbortAfterWaitOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
