using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexExpressionOption : IndexOption, IEquatable<IndexExpressionOption> {
        protected ScalarExpression expression;
    
        public ScalarExpression Expression => expression;
    
        public IndexExpressionOption(ScalarExpression expression = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.expression = expression;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IndexExpressionOption ToMutableConcrete() {
            var ret = new ScriptDom.IndexExpressionOption();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexExpressionOption);
        } 
        
        public bool Equals(IndexExpressionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexExpressionOption left, IndexExpressionOption right) {
            return EqualityComparer<IndexExpressionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexExpressionOption left, IndexExpressionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IndexExpressionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IndexExpressionOption left, IndexExpressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IndexExpressionOption left, IndexExpressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IndexExpressionOption left, IndexExpressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IndexExpressionOption left, IndexExpressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
