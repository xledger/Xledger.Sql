using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsTriggerOption : TriggerOption, IEquatable<ExecuteAsTriggerOption> {
        protected ExecuteAsClause executeAsClause;
    
        public ExecuteAsClause ExecuteAsClause => executeAsClause;
    
        public ExecuteAsTriggerOption(ExecuteAsClause executeAsClause = null, ScriptDom.TriggerOptionKind optionKind = ScriptDom.TriggerOptionKind.Encryption) {
            this.executeAsClause = executeAsClause;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExecuteAsTriggerOption ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsTriggerOption();
            ret.ExecuteAsClause = (ScriptDom.ExecuteAsClause)executeAsClause.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeAsClause is null)) {
                h = h * 23 + executeAsClause.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsTriggerOption);
        } 
        
        public bool Equals(ExecuteAsTriggerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.ExecuteAsClause, executeAsClause)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TriggerOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) {
            return EqualityComparer<ExecuteAsTriggerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) {
            return !(left == right);
        }
    
    }

}
