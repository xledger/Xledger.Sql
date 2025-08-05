using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintStateOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintStateOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public DropClusteredConstraintStateOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintStateOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintStateOption();
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
            return Equals(obj as DropClusteredConstraintStateOption);
        } 
        
        public bool Equals(DropClusteredConstraintStateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropClusteredConstraintOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) {
            return EqualityComparer<DropClusteredConstraintStateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropClusteredConstraintStateOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropClusteredConstraintStateOption left, DropClusteredConstraintStateOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropClusteredConstraintStateOption FromMutable(ScriptDom.DropClusteredConstraintStateOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropClusteredConstraintStateOption)) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintStateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
