using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarExpressionDialogOption : DialogOption, IEquatable<ScalarExpressionDialogOption> {
        protected ScalarExpression @value;
    
        public ScalarExpression Value => @value;
    
        public ScalarExpressionDialogOption(ScalarExpression @value = null, ScriptDom.DialogOptionKind optionKind = ScriptDom.DialogOptionKind.RelatedConversation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ScalarExpressionDialogOption ToMutableConcrete() {
            var ret = new ScriptDom.ScalarExpressionDialogOption();
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ScalarExpressionDialogOption);
        } 
        
        public bool Equals(ScalarExpressionDialogOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DialogOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) {
            return EqualityComparer<ScalarExpressionDialogOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) {
            return !(left == right);
        }
    
    }

}
