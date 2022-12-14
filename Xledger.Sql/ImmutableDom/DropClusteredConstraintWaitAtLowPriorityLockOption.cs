using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintWaitAtLowPriorityLockOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintWaitAtLowPriorityLockOption> {
        protected IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public DropClusteredConstraintWaitAtLowPriorityLockOption(IReadOnlyList<LowPriorityLockWaitOption> options = null, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.options = ImmList<LowPriorityLockWaitOption>.FromList(options);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.LowPriorityLockWaitOption)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropClusteredConstraintWaitAtLowPriorityLockOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropClusteredConstraintWaitAtLowPriorityLockOption left, DropClusteredConstraintWaitAtLowPriorityLockOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropClusteredConstraintWaitAtLowPriorityLockOption FromMutable(ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption fragment) {
            return (DropClusteredConstraintWaitAtLowPriorityLockOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
