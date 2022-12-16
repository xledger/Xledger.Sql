using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnlineIndexLowPriorityLockWaitOption : TSqlFragment, IEquatable<OnlineIndexLowPriorityLockWaitOption> {
        protected IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public OnlineIndexLowPriorityLockWaitOption(IReadOnlyList<LowPriorityLockWaitOption> options = null) {
            this.options = ImmList<LowPriorityLockWaitOption>.FromList(options);
        }
    
        public ScriptDom.OnlineIndexLowPriorityLockWaitOption ToMutableConcrete() {
            var ret = new ScriptDom.OnlineIndexLowPriorityLockWaitOption();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.LowPriorityLockWaitOption)c?.ToMutable()));
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
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnlineIndexLowPriorityLockWaitOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnlineIndexLowPriorityLockWaitOption left, OnlineIndexLowPriorityLockWaitOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
