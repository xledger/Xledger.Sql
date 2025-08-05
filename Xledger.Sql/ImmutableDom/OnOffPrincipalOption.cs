using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffPrincipalOption : PrincipalOption, IEquatable<OnOffPrincipalOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffPrincipalOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.OnOffPrincipalOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffPrincipalOption();
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
            return Equals(obj as OnOffPrincipalOption);
        } 
        
        public bool Equals(OnOffPrincipalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PrincipalOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffPrincipalOption left, OnOffPrincipalOption right) {
            return EqualityComparer<OnOffPrincipalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffPrincipalOption left, OnOffPrincipalOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffPrincipalOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OnOffPrincipalOption left, OnOffPrincipalOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnOffPrincipalOption left, OnOffPrincipalOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnOffPrincipalOption left, OnOffPrincipalOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnOffPrincipalOption left, OnOffPrincipalOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnOffPrincipalOption FromMutable(ScriptDom.OnOffPrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OnOffPrincipalOption)) { throw new NotImplementedException("Unexpected subtype of OnOffPrincipalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffPrincipalOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
