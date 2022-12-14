using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffPrimaryConfigurationOption : DatabaseConfigurationSetOption, IEquatable<OnOffPrimaryConfigurationOption> {
        protected ScriptDom.DatabaseConfigurationOptionState optionState = ScriptDom.DatabaseConfigurationOptionState.NotSet;
    
        public ScriptDom.DatabaseConfigurationOptionState OptionState => optionState;
    
        public OnOffPrimaryConfigurationOption(ScriptDom.DatabaseConfigurationOptionState optionState = ScriptDom.DatabaseConfigurationOptionState.NotSet, ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.optionState = optionState;
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public ScriptDom.OnOffPrimaryConfigurationOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffPrimaryConfigurationOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnOffPrimaryConfigurationOption);
        } 
        
        public bool Equals(OnOffPrimaryConfigurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseConfigurationOptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseConfigSetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GenericOptionKind, genericOptionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) {
            return EqualityComparer<OnOffPrimaryConfigurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffPrimaryConfigurationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.genericOptionKind, othr.genericOptionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnOffPrimaryConfigurationOption left, OnOffPrimaryConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnOffPrimaryConfigurationOption FromMutable(ScriptDom.OnOffPrimaryConfigurationOption fragment) {
            return (OnOffPrimaryConfigurationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
