using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarExpressionRestoreOption : RestoreOption, IEquatable<ScalarExpressionRestoreOption> {
        protected ScalarExpression @value;
    
        public ScalarExpression Value => @value;
    
        public ScalarExpressionRestoreOption(ScalarExpression @value = null, ScriptDom.RestoreOptionKind optionKind = 0) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ScalarExpressionRestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.ScalarExpressionRestoreOption();
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
            return Equals(obj as ScalarExpressionRestoreOption);
        } 
        
        public bool Equals(ScalarExpressionRestoreOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RestoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) {
            return EqualityComparer<ScalarExpressionRestoreOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ScalarExpressionRestoreOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ScalarExpressionRestoreOption left, ScalarExpressionRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ScalarExpressionRestoreOption FromMutable(ScriptDom.ScalarExpressionRestoreOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ScalarExpressionRestoreOption)) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionRestoreOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionRestoreOption(
                @value: ImmutableDom.ScalarExpression.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
