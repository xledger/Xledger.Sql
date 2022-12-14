using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreMaxPlansPerQueryOption : QueryStoreOption, IEquatable<QueryStoreMaxPlansPerQueryOption> {
        protected Literal maxPlansPerQuery;
    
        public Literal MaxPlansPerQuery => maxPlansPerQuery;
    
        public QueryStoreMaxPlansPerQueryOption(Literal maxPlansPerQuery = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.maxPlansPerQuery = maxPlansPerQuery;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreMaxPlansPerQueryOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreMaxPlansPerQueryOption();
            ret.MaxPlansPerQuery = (ScriptDom.Literal)maxPlansPerQuery.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxPlansPerQuery is null)) {
                h = h * 23 + maxPlansPerQuery.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreMaxPlansPerQueryOption);
        } 
        
        public bool Equals(QueryStoreMaxPlansPerQueryOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxPlansPerQuery, maxPlansPerQuery)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) {
            return EqualityComparer<QueryStoreMaxPlansPerQueryOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreMaxPlansPerQueryOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.maxPlansPerQuery, othr.maxPlansPerQuery);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreMaxPlansPerQueryOption left, QueryStoreMaxPlansPerQueryOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreMaxPlansPerQueryOption FromMutable(ScriptDom.QueryStoreMaxPlansPerQueryOption fragment) {
            return (QueryStoreMaxPlansPerQueryOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
