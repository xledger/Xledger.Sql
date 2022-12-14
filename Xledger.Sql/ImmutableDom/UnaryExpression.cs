using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UnaryExpression : ScalarExpression, IEquatable<UnaryExpression> {
        protected ScriptDom.UnaryExpressionType unaryExpressionType = ScriptDom.UnaryExpressionType.Positive;
        protected ScalarExpression expression;
    
        public ScriptDom.UnaryExpressionType UnaryExpressionType => unaryExpressionType;
        public ScalarExpression Expression => expression;
    
        public UnaryExpression(ScriptDom.UnaryExpressionType unaryExpressionType = ScriptDom.UnaryExpressionType.Positive, ScalarExpression expression = null) {
            this.unaryExpressionType = unaryExpressionType;
            this.expression = expression;
        }
    
        public ScriptDom.UnaryExpression ToMutableConcrete() {
            var ret = new ScriptDom.UnaryExpression();
            ret.UnaryExpressionType = unaryExpressionType;
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + unaryExpressionType.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UnaryExpression);
        } 
        
        public bool Equals(UnaryExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.UnaryExpressionType>.Default.Equals(other.UnaryExpressionType, unaryExpressionType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UnaryExpression left, UnaryExpression right) {
            return EqualityComparer<UnaryExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UnaryExpression left, UnaryExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UnaryExpression)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.unaryExpressionType, othr.unaryExpressionType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static UnaryExpression FromMutable(ScriptDom.UnaryExpression fragment) {
            return (UnaryExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
