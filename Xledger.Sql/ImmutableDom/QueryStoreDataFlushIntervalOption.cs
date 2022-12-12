using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreDataFlushIntervalOption : QueryStoreOption, IEquatable<QueryStoreDataFlushIntervalOption> {
        Literal flushInterval;
    
        public Literal FlushInterval => flushInterval;
    
        public QueryStoreDataFlushIntervalOption(Literal flushInterval = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.flushInterval = flushInterval;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreDataFlushIntervalOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreDataFlushIntervalOption();
            ret.FlushInterval = (ScriptDom.Literal)flushInterval.ToMutable();
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
    
    }

}
