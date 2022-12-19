using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MemoryOptimizedTableOption : TableOption, IEquatable<MemoryOptimizedTableOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public MemoryOptimizedTableOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MemoryOptimizedTableOption ToMutableConcrete() {
            var ret = new ScriptDom.MemoryOptimizedTableOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MemoryOptimizedTableOption);
        } 
        
        public bool Equals(MemoryOptimizedTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) {
            return EqualityComparer<MemoryOptimizedTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MemoryOptimizedTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MemoryOptimizedTableOption FromMutable(ScriptDom.MemoryOptimizedTableOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MemoryOptimizedTableOption)) { throw new NotImplementedException("Unexpected subtype of MemoryOptimizedTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MemoryOptimizedTableOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
