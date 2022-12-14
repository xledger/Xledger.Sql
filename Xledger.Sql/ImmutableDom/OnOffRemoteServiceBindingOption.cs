using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffRemoteServiceBindingOption : RemoteServiceBindingOption, IEquatable<OnOffRemoteServiceBindingOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffRemoteServiceBindingOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.RemoteServiceBindingOptionKind optionKind = ScriptDom.RemoteServiceBindingOptionKind.User) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffRemoteServiceBindingOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffRemoteServiceBindingOption();
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
            return Equals(obj as OnOffRemoteServiceBindingOption);
        } 
        
        public bool Equals(OnOffRemoteServiceBindingOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteServiceBindingOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffRemoteServiceBindingOption left, OnOffRemoteServiceBindingOption right) {
            return EqualityComparer<OnOffRemoteServiceBindingOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffRemoteServiceBindingOption left, OnOffRemoteServiceBindingOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffRemoteServiceBindingOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OnOffRemoteServiceBindingOption FromMutable(ScriptDom.OnOffRemoteServiceBindingOption fragment) {
            return (OnOffRemoteServiceBindingOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
