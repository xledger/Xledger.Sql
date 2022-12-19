using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchLastNodePredicate : BooleanExpression, IEquatable<GraphMatchLastNodePredicate> {
        protected GraphMatchNodeExpression leftExpression;
        protected GraphMatchNodeExpression rightExpression;
    
        public GraphMatchNodeExpression LeftExpression => leftExpression;
        public GraphMatchNodeExpression RightExpression => rightExpression;
    
        public GraphMatchLastNodePredicate(GraphMatchNodeExpression leftExpression = null, GraphMatchNodeExpression rightExpression = null) {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }
    
        public ScriptDom.GraphMatchLastNodePredicate ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchLastNodePredicate();
            ret.LeftExpression = (ScriptDom.GraphMatchNodeExpression)leftExpression?.ToMutable();
            ret.RightExpression = (ScriptDom.GraphMatchNodeExpression)rightExpression?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphMatchLastNodePredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.leftExpression, othr.leftExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.rightExpression, othr.rightExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphMatchLastNodePredicate left, GraphMatchLastNodePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GraphMatchLastNodePredicate FromMutable(ScriptDom.GraphMatchLastNodePredicate fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GraphMatchLastNodePredicate)) { throw new NotImplementedException("Unexpected subtype of GraphMatchLastNodePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchLastNodePredicate(
                leftExpression: ImmutableDom.GraphMatchNodeExpression.FromMutable(fragment.LeftExpression),
                rightExpression: ImmutableDom.GraphMatchNodeExpression.FromMutable(fragment.RightExpression)
            );
        }
    
    }

}
