using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreMaxStorageSizeOption : QueryStoreOption, IEquatable<QueryStoreMaxStorageSizeOption> {
        Literal maxQdsSize;
    
        public Literal MaxQdsSize => maxQdsSize;
    
        public QueryStoreMaxStorageSizeOption(Literal maxQdsSize = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.maxQdsSize = maxQdsSize;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreMaxStorageSizeOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreMaxStorageSizeOption();
            ret.MaxQdsSize = (ScriptDom.Literal)maxQdsSize.ToMutable();
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
    
    }

}
