using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanNotExpression : BooleanExpression, IEquatable<BooleanNotExpression> {
        BooleanExpression expression;
    
        public BooleanExpression Expression => expression;
    
        public BooleanNotExpression(BooleanExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.BooleanNotExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanNotExpression();
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
            return Equals(obj as BooleanNotExpression);
        } 
        
        public bool Equals(BooleanNotExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanNotExpression left, BooleanNotExpression right) {
            return EqualityComparer<BooleanNotExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanNotExpression left, BooleanNotExpression right) {
            return !(left == right);
        }
    
    }

}
