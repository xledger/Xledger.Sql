using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LowPriorityLockWaitMaxDurationOption : LowPriorityLockWaitOption, IEquatable<LowPriorityLockWaitMaxDurationOption> {
        Literal maxDuration;
        ScriptDom.TimeUnit? unit;
    
        public Literal MaxDuration => maxDuration;
        public ScriptDom.TimeUnit? Unit => unit;
    
        public LowPriorityLockWaitMaxDurationOption(Literal maxDuration = null, ScriptDom.TimeUnit? unit = null, ScriptDom.LowPriorityLockWaitOptionKind optionKind = ScriptDom.LowPriorityLockWaitOptionKind.MaxDuration) {
            this.maxDuration = maxDuration;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LowPriorityLockWaitMaxDurationOption ToMutableConcrete() {
            var ret = new ScriptDom.LowPriorityLockWaitMaxDurationOption();
            ret.MaxDuration = (ScriptDom.Literal)maxDuration.ToMutable();
            ret.Unit = unit;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxDuration is null)) {
                h = h * 23 + maxDuration.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LowPriorityLockWaitMaxDurationOption);
        } 
        
        public bool Equals(LowPriorityLockWaitMaxDurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxDuration, maxDuration)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TimeUnit?>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.LowPriorityLockWaitOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LowPriorityLockWaitMaxDurationOption left, LowPriorityLockWaitMaxDurationOption right) {
            return EqualityComparer<LowPriorityLockWaitMaxDurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LowPriorityLockWaitMaxDurationOption left, LowPriorityLockWaitMaxDurationOption right) {
            return !(left == right);
        }
    
    }

}