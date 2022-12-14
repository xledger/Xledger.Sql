using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffDatabaseOption : DatabaseOption, IEquatable<OnOffDatabaseOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffDatabaseOption();
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
            return Equals(obj as OnOffDatabaseOption);
        } 
        
        public bool Equals(OnOffDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffDatabaseOption left, OnOffDatabaseOption right) {
            return EqualityComparer<OnOffDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffDatabaseOption left, OnOffDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OnOffDatabaseOption left, OnOffDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OnOffDatabaseOption left, OnOffDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OnOffDatabaseOption left, OnOffDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OnOffDatabaseOption left, OnOffDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OnOffDatabaseOption FromMutable(ScriptDom.OnOffDatabaseOption fragment) {
            return (OnOffDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
