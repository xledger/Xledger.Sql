using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreTimeCleanupPolicyOption : QueryStoreOption, IEquatable<QueryStoreTimeCleanupPolicyOption> {
        protected Literal staleQueryThreshold;
    
        public Literal StaleQueryThreshold => staleQueryThreshold;
    
        public QueryStoreTimeCleanupPolicyOption(Literal staleQueryThreshold = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.staleQueryThreshold = staleQueryThreshold;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreTimeCleanupPolicyOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreTimeCleanupPolicyOption();
            ret.StaleQueryThreshold = (ScriptDom.Literal)staleQueryThreshold.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(staleQueryThreshold is null)) {
                h = h * 23 + staleQueryThreshold.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreTimeCleanupPolicyOption);
        } 
        
        public bool Equals(QueryStoreTimeCleanupPolicyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.StaleQueryThreshold, staleQueryThreshold)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) {
            return EqualityComparer<QueryStoreTimeCleanupPolicyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreTimeCleanupPolicyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.staleQueryThreshold, othr.staleQueryThreshold);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreTimeCleanupPolicyOption left, QueryStoreTimeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
