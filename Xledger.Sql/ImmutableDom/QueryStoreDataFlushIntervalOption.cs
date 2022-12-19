using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreDataFlushIntervalOption : QueryStoreOption, IEquatable<QueryStoreDataFlushIntervalOption> {
        protected Literal flushInterval;
    
        public Literal FlushInterval => flushInterval;
    
        public QueryStoreDataFlushIntervalOption(Literal flushInterval = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.flushInterval = flushInterval;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreDataFlushIntervalOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreDataFlushIntervalOption();
            ret.FlushInterval = (ScriptDom.Literal)flushInterval?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(flushInterval is null)) {
                h = h * 23 + flushInterval.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreDataFlushIntervalOption);
        } 
        
        public bool Equals(QueryStoreDataFlushIntervalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.FlushInterval, flushInterval)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) {
            return EqualityComparer<QueryStoreDataFlushIntervalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreDataFlushIntervalOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.flushInterval, othr.flushInterval);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreDataFlushIntervalOption left, QueryStoreDataFlushIntervalOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreDataFlushIntervalOption FromMutable(ScriptDom.QueryStoreDataFlushIntervalOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryStoreDataFlushIntervalOption)) { throw new NotImplementedException("Unexpected subtype of QueryStoreDataFlushIntervalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreDataFlushIntervalOption(
                flushInterval: ImmutableDom.Literal.FromMutable(fragment.FlushInterval),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
