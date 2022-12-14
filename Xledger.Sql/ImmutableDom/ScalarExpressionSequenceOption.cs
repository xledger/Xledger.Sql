using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarExpressionSequenceOption : SequenceOption, IEquatable<ScalarExpressionSequenceOption> {
        protected ScalarExpression optionValue;
    
        public ScalarExpression OptionValue => optionValue;
    
        public ScalarExpressionSequenceOption(ScalarExpression optionValue = null, ScriptDom.SequenceOptionKind optionKind = ScriptDom.SequenceOptionKind.As, bool noValue = false) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
            this.noValue = noValue;
        }
    
        public ScriptDom.ScalarExpressionSequenceOption ToMutableConcrete() {
            var ret = new ScriptDom.ScalarExpressionSequenceOption();
            ret.OptionValue = (ScriptDom.ScalarExpression)optionValue.ToMutable();
            ret.OptionKind = optionKind;
            ret.NoValue = noValue;
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
            h = h * 23 + noValue.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ScalarExpressionSequenceOption);
        } 
        
        public bool Equals(ScalarExpressionSequenceOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SequenceOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NoValue, noValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) {
            return EqualityComparer<ScalarExpressionSequenceOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ScalarExpressionSequenceOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.noValue, othr.noValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ScalarExpressionSequenceOption left, ScalarExpressionSequenceOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ScalarExpressionSequenceOption FromMutable(ScriptDom.ScalarExpressionSequenceOption fragment) {
            return (ScalarExpressionSequenceOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
