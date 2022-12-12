using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UnaryExpression : ScalarExpression, IEquatable<UnaryExpression> {
        ScriptDom.UnaryExpressionType unaryExpressionType = ScriptDom.UnaryExpressionType.Positive;
        ScalarExpression expression;
    
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
    
    }

}