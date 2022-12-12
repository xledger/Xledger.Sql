using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreDesiredStateOption : QueryStoreOption, IEquatable<QueryStoreDesiredStateOption> {
        ScriptDom.QueryStoreDesiredStateOptionKind @value = ScriptDom.QueryStoreDesiredStateOptionKind.Off;
        bool operationModeSpecified = false;
    
        public ScriptDom.QueryStoreDesiredStateOptionKind Value => @value;
        public bool OperationModeSpecified => operationModeSpecified;
    
        public QueryStoreDesiredStateOption(ScriptDom.QueryStoreDesiredStateOptionKind @value = ScriptDom.QueryStoreDesiredStateOptionKind.Off, bool operationModeSpecified = false, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.@value = @value;
            this.operationModeSpecified = operationModeSpecified;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreDesiredStateOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreDesiredStateOption();
            ret.Value = @value;
            ret.OperationModeSpecified = operationModeSpecified;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + operationModeSpecified.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreDesiredStateOption);
        } 
        
        public bool Equals(QueryStoreDesiredStateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QueryStoreDesiredStateOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.OperationModeSpecified, operationModeSpecified)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreDesiredStateOption left, QueryStoreDesiredStateOption right) {
            return EqualityComparer<QueryStoreDesiredStateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreDesiredStateOption left, QueryStoreDesiredStateOption right) {
            return !(left == right);
        }
    
    }

}