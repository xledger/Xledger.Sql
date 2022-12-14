using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityPolicyOption : TSqlFragment, IEquatable<SecurityPolicyOption> {
        protected ScriptDom.SecurityPolicyOptionKind optionKind = ScriptDom.SecurityPolicyOptionKind.State;
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.SecurityPolicyOptionKind OptionKind => optionKind;
        public ScriptDom.OptionState OptionState => optionState;
    
        public SecurityPolicyOption(ScriptDom.SecurityPolicyOptionKind optionKind = ScriptDom.SecurityPolicyOptionKind.State, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet) {
            this.optionKind = optionKind;
            this.optionState = optionState;
        }
    
        public ScriptDom.SecurityPolicyOption ToMutableConcrete() {
            var ret = new ScriptDom.SecurityPolicyOption();
            ret.OptionKind = optionKind;
            ret.OptionState = optionState;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + optionState.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityPolicyOption);
        } 
        
        public bool Equals(SecurityPolicyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SecurityPolicyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityPolicyOption left, SecurityPolicyOption right) {
            return EqualityComparer<SecurityPolicyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityPolicyOption left, SecurityPolicyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecurityPolicyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SecurityPolicyOption left, SecurityPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SecurityPolicyOption left, SecurityPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SecurityPolicyOption left, SecurityPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SecurityPolicyOption left, SecurityPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SecurityPolicyOption FromMutable(ScriptDom.SecurityPolicyOption fragment) {
            return (SecurityPolicyOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
