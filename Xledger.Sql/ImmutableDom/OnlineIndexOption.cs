using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnlineIndexOption : IndexStateOption, IEquatable<OnlineIndexOption> {
        OnlineIndexLowPriorityLockWaitOption lowPriorityLockWaitOption;
    
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
    
    }

}
