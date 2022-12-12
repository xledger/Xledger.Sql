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
    
    }

}
