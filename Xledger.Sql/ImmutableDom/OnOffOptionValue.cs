using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffOptionValue : OptionValue, IEquatable<OnOffOptionValue> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffOptionValue(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet) {
            this.optionState = optionState;
        }
    
        public ScriptDom.OnOffOptionValue ToMutableConcrete() {
            var ret = new ScriptDom.OnOffOptionValue();
            ret.OptionState = optionState;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnOffOptionValue);
        } 
        
        public bool Equals(OnOffOptionValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffOptionValue left, OnOffOptionValue right) {
            return EqualityComparer<OnOffOptionValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffOptionValue left, OnOffOptionValue right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffOptionValue)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OnOffOptionValue left, OnOffOptionValue right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnOffOptionValue left, OnOffOptionValue right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnOffOptionValue left, OnOffOptionValue right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnOffOptionValue left, OnOffOptionValue right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnOffOptionValue FromMutable(ScriptDom.OnOffOptionValue fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OnOffOptionValue)) { throw new NotImplementedException("Unexpected subtype of OnOffOptionValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffOptionValue(
                optionState: fragment.OptionState
            );
        }
    
    }

}
