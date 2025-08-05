using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            ret.Value = (ScriptDom.ScalarExpression)@value?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ScalarExpressionDialogOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ScalarExpressionDialogOption left, ScalarExpressionDialogOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ScalarExpressionDialogOption FromMutable(ScriptDom.ScalarExpressionDialogOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ScalarExpressionDialogOption)) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionDialogOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionDialogOption(
                @value: ImmutableDom.ScalarExpression.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
