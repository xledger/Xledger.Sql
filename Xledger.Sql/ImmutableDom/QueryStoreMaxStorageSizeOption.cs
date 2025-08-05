using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreMaxStorageSizeOption : QueryStoreOption, IEquatable<QueryStoreMaxStorageSizeOption> {
        protected Literal maxQdsSize;
    
        public Literal MaxQdsSize => maxQdsSize;
    
        public QueryStoreMaxStorageSizeOption(Literal maxQdsSize = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.maxQdsSize = maxQdsSize;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreMaxStorageSizeOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreMaxStorageSizeOption();
            ret.MaxQdsSize = (ScriptDom.Literal)maxQdsSize?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxQdsSize is null)) {
                h = h * 23 + maxQdsSize.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreMaxStorageSizeOption);
        } 
        
        public bool Equals(QueryStoreMaxStorageSizeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxQdsSize, maxQdsSize)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) {
            return EqualityComparer<QueryStoreMaxStorageSizeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryStoreMaxStorageSizeOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.maxQdsSize, othr.maxQdsSize);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryStoreMaxStorageSizeOption left, QueryStoreMaxStorageSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryStoreMaxStorageSizeOption FromMutable(ScriptDom.QueryStoreMaxStorageSizeOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryStoreMaxStorageSizeOption)) { throw new NotImplementedException("Unexpected subtype of QueryStoreMaxStorageSizeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreMaxStorageSizeOption(
                maxQdsSize: ImmutableDom.Literal.FromMutable(fragment.MaxQdsSize),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
