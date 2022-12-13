using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanParenthesisExpression : BooleanExpression, IEquatable<BooleanParenthesisExpression> {
        protected BooleanExpression expression;
    
        public BooleanExpression Expression => expression;
    
        public BooleanParenthesisExpression(BooleanExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.BooleanParenthesisExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanParenthesisExpression();
            ret.Expression = (ScriptDom.BooleanExpression)expression.ToMutable();
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
            return Equals(obj as BooleanParenthesisExpression);
        } 
        
        public bool Equals(BooleanParenthesisExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanParenthesisExpression left, BooleanParenthesisExpression right) {
            return EqualityComparer<BooleanParenthesisExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanParenthesisExpression left, BooleanParenthesisExpression right) {
            return !(left == right);
        }
    
        public static BooleanParenthesisExpression FromMutable(ScriptDom.BooleanParenthesisExpression fragment) {
            return (BooleanParenthesisExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
