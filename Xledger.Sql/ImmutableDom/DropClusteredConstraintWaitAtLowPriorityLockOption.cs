using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintWaitAtLowPriorityLockOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintWaitAtLowPriorityLockOption> {
        IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public DropClusteredConstraintWaitAtLowPriorityLockOption(IReadOnlyList<LowPriorityLockWaitOption> options = null, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.options = options is null ? ImmList<LowPriorityLockWaitOption>.Empty : ImmList<LowPriorityLockWaitOption>.FromList(options);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption();
            ret.Options.AddRange(options.Select(c => (ScriptDom.LowPriorityLockWaitOption)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropClusteredConstraintWaitAtLowPriorityLockOption);
        } 
        
        public bool Equals(DropClusteredConstraintWaitAtLowPriorityLockOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<LowPriorityLockWaitOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropClusteredConstraintOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) {
            return EqualityComparer<DropClusteredConstraintWaitAtLowPriorityLockOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) {
            return !(left == right);
        }
    
    }

}