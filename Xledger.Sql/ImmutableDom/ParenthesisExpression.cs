using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ParenthesisExpression : PrimaryExpression, IEquatable<ParenthesisExpression> {
        ScalarExpression expression;
    
        public ScalarExpression Expression => expression;
    
        public ParenthesisExpression(ScalarExpression expression = null, Identifier collation = null) {
            this.expression = expression;
            this.collation = collation;
        }
    
        public ScriptDom.ParenthesisExpression ToMutableConcrete() {
            var ret = new ScriptDom.ParenthesisExpression();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
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
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ParenthesisExpression);
        } 
        
        public bool Equals(ParenthesisExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ParenthesisExpression left, ParenthesisExpression right) {
            return EqualityComparer<ParenthesisExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ParenthesisExpression left, ParenthesisExpression right) {
            return !(left == right);
        }
    
    }

}