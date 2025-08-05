using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnlineIndexLowPriorityLockWaitOption : TSqlFragment, IEquatable<OnlineIndexLowPriorityLockWaitOption> {
        protected IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public OnlineIndexLowPriorityLockWaitOption(IReadOnlyList<LowPriorityLockWaitOption> options = null) {
            this.options = options.ToImmArray<LowPriorityLockWaitOption>();
        }
    
        public ScriptDom.OnlineIndexLowPriorityLockWaitOption ToMutableConcrete() {
            var ret = new ScriptDom.OnlineIndexLowPriorityLockWaitOption();
            ret.Options.AddRange(options.Select(c => (ScriptDom.LowPriorityLockWaitOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnlineIndexLowPriorityLockWaitOption);
        } 
        
        public bool Equals(OnlineIndexLowPriorityLockWaitOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<LowPriorityLockWaitOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) {
            return EqualityComparer<OnlineIndexLowPriorityLockWaitOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnlineIndexLowPriorityLockWaitOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnlineIndexLowPriorityLockWaitOption FromMutable(ScriptDom.OnlineIndexLowPriorityLockWaitOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OnlineIndexLowPriorityLockWaitOption)) { throw new NotImplementedException("Unexpected subtype of OnlineIndexLowPriorityLockWaitOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnlineIndexLowPriorityLockWaitOption(
                options: fragment.Options.ToImmArray(ImmutableDom.LowPriorityLockWaitOption.FromMutable)
            );
        }
    
    }

}
