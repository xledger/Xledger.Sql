using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
    
        public ScriptDom.OnlineIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.OnlineIndexOption();
            ret.LowPriorityLockWaitOption = (ScriptDom.OnlineIndexLowPriorityLockWaitOption)lowPriorityLockWaitOption.ToMutable();
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
            compare = StructuralComparisons.StructuralComparer.Compare(this.lowPriorityLockWaitOption, othr.lowPriorityLockWaitOption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OnlineIndexOption FromMutable(ScriptDom.OnlineIndexOption fragment) {
            return (OnlineIndexOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
