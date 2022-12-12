using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchCompositeExpression : BooleanExpression, IEquatable<GraphMatchCompositeExpression> {
        GraphMatchNodeExpression leftNode;
        Identifier edge;
        GraphMatchNodeExpression rightNode;
        bool arrowOnRight = false;
    
        public GraphMatchNodeExpression LeftNode => leftNode;
        public Identifier Edge => edge;
        public GraphMatchNodeExpression RightNode => rightNode;
        public bool ArrowOnRight => arrowOnRight;
    
        public GraphMatchCompositeExpression(GraphMatchNodeExpression leftNode = null, Identifier edge = null, GraphMatchNodeExpression rightNode = null, bool arrowOnRight = false) {
            this.leftNode = leftNode;
            this.edge = edge;
            this.rightNode = rightNode;
            this.arrowOnRight = arrowOnRight;
        }
    
        public ScriptDom.GraphMatchCompositeExpression ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchCompositeExpression();
            ret.LeftNode = (ScriptDom.GraphMatchNodeExpression)leftNode.ToMutable();
            ret.Edge = (ScriptDom.Identifier)edge.ToMutable();
            ret.RightNode = (ScriptDom.GraphMatchNodeExpression)rightNode.ToMutable();
            ret.ArrowOnRight = arrowOnRight;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(leftNode is null)) {
                h = h * 23 + leftNode.GetHashCode();
            }
            if (!(edge is null)) {
                h = h * 23 + edge.GetHashCode();
            }
            if (!(rightNode is null)) {
                h = h * 23 + rightNode.GetHashCode();
            }
            h = h * 23 + arrowOnRight.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphMatchCompositeExpression);
        } 
        
        public bool Equals(GraphMatchCompositeExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<GraphMatchNodeExpression>.Default.Equals(other.LeftNode, leftNode)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Edge, edge)) {
                return false;
            }
            if (!EqualityComparer<GraphMatchNodeExpression>.Default.Equals(other.RightNode, rightNode)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ArrowOnRight, arrowOnRight)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchCompositeExpression left, GraphMatchCompositeExpression right) {
            return EqualityComparer<GraphMatchCompositeExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchCompositeExpression left, GraphMatchCompositeExpression right) {
            return !(left == right);
        }
    
    }

}
