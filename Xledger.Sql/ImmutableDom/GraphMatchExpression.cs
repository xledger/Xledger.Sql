using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchExpression : BooleanExpression, IEquatable<GraphMatchExpression> {
        protected Identifier leftNode;
        protected Identifier edge;
        protected Identifier rightNode;
        protected bool arrowOnRight = false;
    
        public Identifier LeftNode => leftNode;
        public Identifier Edge => edge;
        public Identifier RightNode => rightNode;
        public bool ArrowOnRight => arrowOnRight;
    
        public GraphMatchExpression(Identifier leftNode = null, Identifier edge = null, Identifier rightNode = null, bool arrowOnRight = false) {
            this.leftNode = leftNode;
            this.edge = edge;
            this.rightNode = rightNode;
            this.arrowOnRight = arrowOnRight;
        }
    
        public ScriptDom.GraphMatchExpression ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchExpression();
            ret.LeftNode = (ScriptDom.Identifier)leftNode.ToMutable();
            ret.Edge = (ScriptDom.Identifier)edge.ToMutable();
            ret.RightNode = (ScriptDom.Identifier)rightNode.ToMutable();
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
            return Equals(obj as GraphMatchExpression);
        } 
        
        public bool Equals(GraphMatchExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.LeftNode, leftNode)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Edge, edge)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.RightNode, rightNode)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ArrowOnRight, arrowOnRight)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchExpression left, GraphMatchExpression right) {
            return EqualityComparer<GraphMatchExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchExpression left, GraphMatchExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphMatchExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.leftNode, othr.leftNode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.edge, othr.edge);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.rightNode, othr.rightNode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.arrowOnRight, othr.arrowOnRight);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GraphMatchExpression left, GraphMatchExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphMatchExpression left, GraphMatchExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphMatchExpression left, GraphMatchExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphMatchExpression left, GraphMatchExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GraphMatchExpression FromMutable(ScriptDom.GraphMatchExpression fragment) {
            return (GraphMatchExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
