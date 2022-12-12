using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchLastNodePredicate : BooleanExpression, IEquatable<GraphMatchLastNodePredicate> {
        GraphMatchNodeExpression leftExpression;
        GraphMatchNodeExpression rightExpression;
    
        public GraphMatchNodeExpression LeftExpression => leftExpression;
        public GraphMatchNodeExpression RightExpression => rightExpression;
    
        public GraphMatchLastNodePredicate(GraphMatchNodeExpression leftExpression = null, GraphMatchNodeExpression rightExpression = null) {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }
    
        public ScriptDom.GraphMatchLastNodePredicate ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchLastNodePredicate();
            ret.LeftExpression = (ScriptDom.GraphMatchNodeExpression)leftExpression.ToMutable();
            ret.RightExpression = (ScriptDom.GraphMatchNodeExpression)rightExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(leftExpression is null)) {
                h = h * 23 + leftExpression.GetHashCode();
            }
            if (!(rightExpression is null)) {
                h = h * 23 + rightExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphMatchLastNodePredicate);
        } 
        
        public bool Equals(GraphMatchLastNodePredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<GraphMatchNodeExpression>.Default.Equals(other.LeftExpression, leftExpression)) {
                return false;
            }
            if (!EqualityComparer<GraphMatchNodeExpression>.Default.Equals(other.RightExpression, rightExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) {
            return EqualityComparer<GraphMatchLastNodePredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) {
            return !(left == right);
        }
    
    }

}
