using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExpressionCallTarget : CallTarget, IEquatable<ExpressionCallTarget> {
        ScalarExpression expression;
    
        public ScalarExpression Expression => expression;
    
        public ExpressionCallTarget(ScalarExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.ExpressionCallTarget ToMutableConcrete() {
            var ret = new ScriptDom.ExpressionCallTarget();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExpressionCallTarget);
        } 
        
        public bool Equals(ExpressionCallTarget other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExpressionCallTarget left, ExpressionCallTarget right) {
            return EqualityComparer<ExpressionCallTarget>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExpressionCallTarget left, ExpressionCallTarget right) {
            return !(left == right);
        }
    
    }

}
