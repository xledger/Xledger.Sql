using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExpressionWithSortOrder : TSqlFragment, IEquatable<ExpressionWithSortOrder> {
        protected ScriptDom.SortOrder sortOrder = ScriptDom.SortOrder.NotSpecified;
        protected ScalarExpression expression;
    
        public ScriptDom.SortOrder SortOrder => sortOrder;
        public ScalarExpression Expression => expression;
    
        public ExpressionWithSortOrder(ScriptDom.SortOrder sortOrder = ScriptDom.SortOrder.NotSpecified, ScalarExpression expression = null) {
            this.sortOrder = sortOrder;
            this.expression = expression;
        }
    
        public ScriptDom.ExpressionWithSortOrder ToMutableConcrete() {
            var ret = new ScriptDom.ExpressionWithSortOrder();
            ret.SortOrder = sortOrder;
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sortOrder.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExpressionWithSortOrder);
        } 
        
        public bool Equals(ExpressionWithSortOrder other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SortOrder>.Default.Equals(other.SortOrder, sortOrder)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExpressionWithSortOrder left, ExpressionWithSortOrder right) {
            return EqualityComparer<ExpressionWithSortOrder>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExpressionWithSortOrder left, ExpressionWithSortOrder right) {
            return !(left == right);
        }
    
    }

}
