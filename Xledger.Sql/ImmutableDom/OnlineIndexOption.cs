using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnlineIndexOption : IndexStateOption, IEquatable<OnlineIndexOption> {
        protected OnlineIndexLowPriorityLockWaitOption lowPriorityLockWaitOption;
    
        public OnlineIndexLowPriorityLockWaitOption LowPriorityLockWaitOption => lowPriorityLockWaitOption;
    
        public OnlineIndexOption(OnlineIndexLowPriorityLockWaitOption lowPriorityLockWaitOption = null, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.lowPriorityLockWaitOption = lowPriorityLockWaitOption;
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.OnlineIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.OnlineIndexOption();
            ret.LowPriorityLockWaitOption = (ScriptDom.OnlineIndexLowPriorityLockWaitOption)lowPriorityLockWaitOption?.ToMutable();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(lowPriorityLockWaitOption is null)) {
                h = h * 23 + lowPriorityLockWaitOption.GetHashCode();
            }
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnlineIndexOption);
        } 
        
        public bool Equals(OnlineIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<OnlineIndexLowPriorityLockWaitOption>.Default.Equals(other.LowPriorityLockWaitOption, lowPriorityLockWaitOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnlineIndexOption left, OnlineIndexOption right) {
            return EqualityComparer<OnlineIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnlineIndexOption left, OnlineIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnlineIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.lowPriorityLockWaitOption, othr.lowPriorityLockWaitOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OnlineIndexOption left, OnlineIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnlineIndexOption left, OnlineIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnlineIndexOption left, OnlineIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnlineIndexOption left, OnlineIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnlineIndexOption FromMutable(ScriptDom.OnlineIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OnlineIndexOption)) { throw new NotImplementedException("Unexpected subtype of OnlineIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnlineIndexOption(
                lowPriorityLockWaitOption: ImmutableDom.OnlineIndexLowPriorityLockWaitOption.FromMutable(fragment.LowPriorityLockWaitOption),
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
