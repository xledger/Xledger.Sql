using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueExecuteAsOption : QueueOption, IEquatable<QueueExecuteAsOption> {
        ExecuteAsClause optionValue;
    
        public ExecuteAsClause OptionValue => optionValue;
    
        public QueueExecuteAsOption(ExecuteAsClause optionValue = null, ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueueExecuteAsOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueExecuteAsOption();
            ret.OptionValue = (ScriptDom.ExecuteAsClause)optionValue.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueueExecuteAsOption);
        } 
        
        public bool Equals(QueueExecuteAsOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueExecuteAsOption left, QueueExecuteAsOption right) {
            return EqualityComparer<QueueExecuteAsOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueExecuteAsOption left, QueueExecuteAsOption right) {
            return !(left == right);
        }
    
    }

}
