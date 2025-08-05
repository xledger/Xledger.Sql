using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreWaitStatsCaptureOption : QueryStoreOption, IEquatable<QueryStoreWaitStatsCaptureOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public QueryStoreWaitStatsCaptureOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreWaitStatsCaptureOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreWaitStatsCaptureOption();
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
            return Equals(obj as QueryStoreWaitStatsCaptureOption);
        } 
        
        public bool Equals(QueryStoreWaitStatsCaptureOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) {
            return EqualityComparer<QueryStoreWaitStatsCaptureOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreWaitStatsCaptureOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreWaitStatsCaptureOption left, QueryStoreWaitStatsCaptureOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreWaitStatsCaptureOption FromMutable(ScriptDom.QueryStoreWaitStatsCaptureOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryStoreWaitStatsCaptureOption)) { throw new NotImplementedException("Unexpected subtype of QueryStoreWaitStatsCaptureOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreWaitStatsCaptureOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
