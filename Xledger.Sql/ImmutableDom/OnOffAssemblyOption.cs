using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffAssemblyOption : AssemblyOption, IEquatable<OnOffAssemblyOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffAssemblyOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.AssemblyOptionKind optionKind = ScriptDom.AssemblyOptionKind.PermissionSet) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.OnOffAssemblyOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffAssemblyOption();
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
            return Equals(obj as OnOffAssemblyOption);
        } 
        
        public bool Equals(OnOffAssemblyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssemblyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffAssemblyOption left, OnOffAssemblyOption right) {
            return EqualityComparer<OnOffAssemblyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffAssemblyOption left, OnOffAssemblyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffAssemblyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OnOffAssemblyOption left, OnOffAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnOffAssemblyOption left, OnOffAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnOffAssemblyOption left, OnOffAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnOffAssemblyOption left, OnOffAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnOffAssemblyOption FromMutable(ScriptDom.OnOffAssemblyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OnOffAssemblyOption)) { throw new NotImplementedException("Unexpected subtype of OnOffAssemblyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffAssemblyOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
