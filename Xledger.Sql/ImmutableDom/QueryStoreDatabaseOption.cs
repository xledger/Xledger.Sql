using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreDatabaseOption : DatabaseOption, IEquatable<QueryStoreDatabaseOption> {
        protected bool clear = false;
        protected bool clearAll = false;
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        protected IReadOnlyList<QueryStoreOption> options;
    
        public bool Clear => clear;
        public bool ClearAll => clearAll;
        public ScriptDom.OptionState OptionState => optionState;
        public IReadOnlyList<QueryStoreOption> Options => options;
    
        public QueryStoreDatabaseOption(bool clear = false, bool clearAll = false, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, IReadOnlyList<QueryStoreOption> options = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.clear = clear;
            this.clearAll = clearAll;
            this.optionState = optionState;
            this.options = ImmList<QueryStoreOption>.FromList(options);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreDatabaseOption();
            ret.Clear = clear;
            ret.ClearAll = clearAll;
            ret.OptionState = optionState;
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.QueryStoreOption)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + clear.GetHashCode();
            h = h * 23 + clearAll.GetHashCode();
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreDatabaseOption);
        } 
        
        public bool Equals(QueryStoreDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Clear, clear)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ClearAll, clearAll)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<QueryStoreOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) {
            return EqualityComparer<QueryStoreDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.clear, othr.clear);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.clearAll, othr.clearAll);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreDatabaseOption left, QueryStoreDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
