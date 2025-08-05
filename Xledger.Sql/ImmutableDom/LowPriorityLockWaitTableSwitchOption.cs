using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LowPriorityLockWaitTableSwitchOption : TableSwitchOption, IEquatable<LowPriorityLockWaitTableSwitchOption> {
        protected IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public LowPriorityLockWaitTableSwitchOption(IReadOnlyList<LowPriorityLockWaitOption> options = null, ScriptDom.TableSwitchOptionKind optionKind = ScriptDom.TableSwitchOptionKind.LowPriorityLockWait) {
            this.options = options.ToImmArray<LowPriorityLockWaitOption>();
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LowPriorityLockWaitTableSwitchOption ToMutableConcrete() {
            var ret = new ScriptDom.LowPriorityLockWaitTableSwitchOption();
            ret.Options.AddRange(options.Select(c => (ScriptDom.LowPriorityLockWaitOption)c?.ToMutable()));
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
            return Equals(obj as LowPriorityLockWaitTableSwitchOption);
        } 
        
        public bool Equals(LowPriorityLockWaitTableSwitchOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<LowPriorityLockWaitOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableSwitchOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) {
            return EqualityComparer<LowPriorityLockWaitTableSwitchOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LowPriorityLockWaitTableSwitchOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static LowPriorityLockWaitTableSwitchOption FromMutable(ScriptDom.LowPriorityLockWaitTableSwitchOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.LowPriorityLockWaitTableSwitchOption)) { throw new NotImplementedException("Unexpected subtype of LowPriorityLockWaitTableSwitchOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LowPriorityLockWaitTableSwitchOption(
                options: fragment.Options.ToImmArray(ImmutableDom.LowPriorityLockWaitOption.FromMutable),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
