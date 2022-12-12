using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanIsNullExpression : BooleanExpression, IEquatable<BooleanIsNullExpression> {
        bool isNot = false;
        ScalarExpression expression;
    
        public bool IsNot => isNot;
        public ScalarExpression Expression => expression;
    
        public BooleanIsNullExpression(bool isNot = false, ScalarExpression expression = null) {
            this.isNot = isNot;
            this.expression = expression;
        }
    
        public ScriptDom.BooleanIsNullExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanIsNullExpression();
            ret.IsNot = isNot;
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isNot.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanIsNullExpression);
        } 
        
        public bool Equals(BooleanIsNullExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNot, isNot)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanIsNullExpression left, BooleanIsNullExpression right) {
            return EqualityComparer<BooleanIsNullExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanIsNullExpression left, BooleanIsNullExpression right) {
            return !(left == right);
        }
    
    }

}
