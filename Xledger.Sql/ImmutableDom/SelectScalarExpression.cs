using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectScalarExpression : SelectElement, IEquatable<SelectScalarExpression> {
        ScalarExpression expression;
        IdentifierOrValueExpression columnName;
    
        public ScalarExpression Expression => expression;
        public IdentifierOrValueExpression ColumnName => columnName;
    
        public SelectScalarExpression(ScalarExpression expression = null, IdentifierOrValueExpression columnName = null) {
            this.expression = expression;
            this.columnName = columnName;
        }
    
        public ScriptDom.SelectScalarExpression ToMutableConcrete() {
            var ret = new ScriptDom.SelectScalarExpression();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.ColumnName = (ScriptDom.IdentifierOrValueExpression)columnName.ToMutable();
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
            if (!(columnName is null)) {
                h = h * 23 + columnName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectScalarExpression);
        } 
        
        public bool Equals(SelectScalarExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.ColumnName, columnName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectScalarExpression left, SelectScalarExpression right) {
            return EqualityComparer<SelectScalarExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectScalarExpression left, SelectScalarExpression right) {
            return !(left == right);
        }
    
    }

}