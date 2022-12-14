using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphConnectionBetweenNodes : TSqlFragment, IEquatable<GraphConnectionBetweenNodes> {
        protected SchemaObjectName fromNode;
        protected SchemaObjectName toNode;
    
        public SchemaObjectName FromNode => fromNode;
        public SchemaObjectName ToNode => toNode;
    
        public GraphConnectionBetweenNodes(SchemaObjectName fromNode = null, SchemaObjectName toNode = null) {
            this.fromNode = fromNode;
            this.toNode = toNode;
        }
    
        public ScriptDom.GraphConnectionBetweenNodes ToMutableConcrete() {
            var ret = new ScriptDom.GraphConnectionBetweenNodes();
            ret.FromNode = (ScriptDom.SchemaObjectName)fromNode.ToMutable();
            ret.ToNode = (ScriptDom.SchemaObjectName)toNode.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fromNode is null)) {
                h = h * 23 + fromNode.GetHashCode();
            }
            if (!(toNode is null)) {
                h = h * 23 + toNode.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphConnectionBetweenNodes);
        } 
        
        public bool Equals(GraphConnectionBetweenNodes other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.FromNode, fromNode)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ToNode, toNode)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) {
            return EqualityComparer<GraphConnectionBetweenNodes>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphConnectionBetweenNodes)that;
            compare = Comparer.DefaultInvariant.Compare(this.fromNode, othr.fromNode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.toNode, othr.toNode);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphConnectionBetweenNodes left, GraphConnectionBetweenNodes right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GraphConnectionBetweenNodes FromMutable(ScriptDom.GraphConnectionBetweenNodes fragment) {
            return (GraphConnectionBetweenNodes)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
