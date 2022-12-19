using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreCapturePolicyOption : QueryStoreOption, IEquatable<QueryStoreCapturePolicyOption> {
        protected ScriptDom.QueryStoreCapturePolicyOptionKind @value = ScriptDom.QueryStoreCapturePolicyOptionKind.NONE;
    
        public ScriptDom.QueryStoreCapturePolicyOptionKind Value => @value;
    
        public QueryStoreCapturePolicyOption(ScriptDom.QueryStoreCapturePolicyOptionKind @value = ScriptDom.QueryStoreCapturePolicyOptionKind.NONE, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreCapturePolicyOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreCapturePolicyOption();
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
            return Equals(obj as QueryStoreCapturePolicyOption);
        } 
        
        public bool Equals(QueryStoreCapturePolicyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QueryStoreCapturePolicyOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) {
            return EqualityComparer<QueryStoreCapturePolicyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreCapturePolicyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreCapturePolicyOption left, QueryStoreCapturePolicyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreCapturePolicyOption FromMutable(ScriptDom.QueryStoreCapturePolicyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryStoreCapturePolicyOption)) { throw new NotImplementedException("Unexpected subtype of QueryStoreCapturePolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreCapturePolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
