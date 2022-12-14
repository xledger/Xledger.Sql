using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption, IEquatable<AutoCreateStatisticsDatabaseOption> {
        protected bool hasIncremental = false;
        protected ScriptDom.OptionState incrementalState = ScriptDom.OptionState.NotSet;
    
        public bool HasIncremental => hasIncremental;
        public ScriptDom.OptionState IncrementalState => incrementalState;
    
        public AutoCreateStatisticsDatabaseOption(bool hasIncremental = false, ScriptDom.OptionState incrementalState = ScriptDom.OptionState.NotSet, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.hasIncremental = hasIncremental;
            this.incrementalState = incrementalState;
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.AutoCreateStatisticsDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.AutoCreateStatisticsDatabaseOption();
            ret.HasIncremental = hasIncremental;
            ret.IncrementalState = incrementalState;
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hasIncremental.GetHashCode();
            h = h * 23 + incrementalState.GetHashCode();
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutoCreateStatisticsDatabaseOption);
        } 
        
        public bool Equals(AutoCreateStatisticsDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.HasIncremental, hasIncremental)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.IncrementalState, incrementalState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) {
            return EqualityComparer<AutoCreateStatisticsDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AutoCreateStatisticsDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.hasIncremental, othr.hasIncremental);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.incrementalState, othr.incrementalState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AutoCreateStatisticsDatabaseOption FromMutable(ScriptDom.AutoCreateStatisticsDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AutoCreateStatisticsDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of AutoCreateStatisticsDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutoCreateStatisticsDatabaseOption(
                hasIncremental: fragment.HasIncremental,
                incrementalState: fragment.IncrementalState,
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
