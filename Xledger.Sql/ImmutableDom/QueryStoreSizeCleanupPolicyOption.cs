using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreSizeCleanupPolicyOption : QueryStoreOption, IEquatable<QueryStoreSizeCleanupPolicyOption> {
        protected ScriptDom.QueryStoreSizeCleanupPolicyOptionKind @value = ScriptDom.QueryStoreSizeCleanupPolicyOptionKind.OFF;
    
        public ScriptDom.QueryStoreSizeCleanupPolicyOptionKind Value => @value;
    
        public QueryStoreSizeCleanupPolicyOption(ScriptDom.QueryStoreSizeCleanupPolicyOptionKind @value = ScriptDom.QueryStoreSizeCleanupPolicyOptionKind.OFF, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreSizeCleanupPolicyOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreSizeCleanupPolicyOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreSizeCleanupPolicyOption);
        } 
        
        public bool Equals(QueryStoreSizeCleanupPolicyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QueryStoreSizeCleanupPolicyOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) {
            return EqualityComparer<QueryStoreSizeCleanupPolicyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreSizeCleanupPolicyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreSizeCleanupPolicyOption FromMutable(ScriptDom.QueryStoreSizeCleanupPolicyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryStoreSizeCleanupPolicyOption)) { throw new NotImplementedException("Unexpected subtype of QueryStoreSizeCleanupPolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreSizeCleanupPolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
