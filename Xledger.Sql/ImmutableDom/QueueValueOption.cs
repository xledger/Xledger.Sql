using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueValueOption : QueueOption, IEquatable<QueueValueOption> {
        ValueExpression optionValue;
    
        public ValueExpression OptionValue => optionValue;
    
        public QueueValueOption(ValueExpression optionValue = null, ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueueValueOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueValueOption();
            ret.OptionValue = (ScriptDom.ValueExpression)optionValue.ToMutable();
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
            return Equals(obj as QueueValueOption);
        } 
        
        public bool Equals(QueueValueOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueValueOption left, QueueValueOption right) {
            return EqualityComparer<QueueValueOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueValueOption left, QueueValueOption right) {
            return !(left == right);
        }
    
    }

}
