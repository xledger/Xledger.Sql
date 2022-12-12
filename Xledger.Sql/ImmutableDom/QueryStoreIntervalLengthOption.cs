using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreIntervalLengthOption : QueryStoreOption, IEquatable<QueryStoreIntervalLengthOption> {
        protected Literal statsIntervalLength;
    
        public Literal StatsIntervalLength => statsIntervalLength;
    
        public QueryStoreIntervalLengthOption(Literal statsIntervalLength = null, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.statsIntervalLength = statsIntervalLength;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreIntervalLengthOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreIntervalLengthOption();
            ret.StatsIntervalLength = (ScriptDom.Literal)statsIntervalLength.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(statsIntervalLength is null)) {
                h = h * 23 + statsIntervalLength.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreIntervalLengthOption);
        } 
        
        public bool Equals(QueryStoreIntervalLengthOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.StatsIntervalLength, statsIntervalLength)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreIntervalLengthOption left, QueryStoreIntervalLengthOption right) {
            return EqualityComparer<QueryStoreIntervalLengthOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreIntervalLengthOption left, QueryStoreIntervalLengthOption right) {
            return !(left == right);
        }
    
    }

}
