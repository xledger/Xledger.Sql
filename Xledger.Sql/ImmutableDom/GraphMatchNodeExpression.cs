using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchNodeExpression : BooleanExpression, IEquatable<GraphMatchNodeExpression> {
        protected Identifier node;
        protected bool usesLastNode = false;
    
        public Identifier Node => node;
        public bool UsesLastNode => usesLastNode;
    
        public GraphMatchNodeExpression(Identifier node = null, bool usesLastNode = false) {
            this.node = node;
            this.usesLastNode = usesLastNode;
        }
    
        public ScriptDom.GraphMatchNodeExpression ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchNodeExpression();
            ret.Node = (ScriptDom.Identifier)node.ToMutable();
            ret.UsesLastNode = usesLastNode;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(node is null)) {
                h = h * 23 + node.GetHashCode();
            }
            h = h * 23 + usesLastNode.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphMatchNodeExpression);
        } 
        
        public bool Equals(GraphMatchNodeExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Node, node)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UsesLastNode, usesLastNode)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchNodeExpression left, GraphMatchNodeExpression right) {
            return EqualityComparer<GraphMatchNodeExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchNodeExpression left, GraphMatchNodeExpression right) {
            return !(left == right);
        }
    
        public static GraphMatchNodeExpression FromMutable(ScriptDom.GraphMatchNodeExpression fragment) {
            return (GraphMatchNodeExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
