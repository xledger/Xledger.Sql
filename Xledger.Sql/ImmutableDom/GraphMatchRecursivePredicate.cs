using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchRecursivePredicate : BooleanExpression, IEquatable<GraphMatchRecursivePredicate> {
        protected ScriptDom.GraphMatchRecursivePredicateKind function = ScriptDom.GraphMatchRecursivePredicateKind.ShortestPath;
        protected GraphMatchNodeExpression outerNodeExpression;
        protected IReadOnlyList<BooleanExpression> expression;
        protected GraphRecursiveMatchQuantifier recursiveQuantifier;
        protected bool anchorOnLeft = false;
    
        public ScriptDom.GraphMatchRecursivePredicateKind Function => function;
        public GraphMatchNodeExpression OuterNodeExpression => outerNodeExpression;
        public IReadOnlyList<BooleanExpression> Expression => expression;
        public GraphRecursiveMatchQuantifier RecursiveQuantifier => recursiveQuantifier;
        public bool AnchorOnLeft => anchorOnLeft;
    
        public GraphMatchRecursivePredicate(ScriptDom.GraphMatchRecursivePredicateKind function = ScriptDom.GraphMatchRecursivePredicateKind.ShortestPath, GraphMatchNodeExpression outerNodeExpression = null, IReadOnlyList<BooleanExpression> expression = null, GraphRecursiveMatchQuantifier recursiveQuantifier = null, bool anchorOnLeft = false) {
            this.function = function;
            this.outerNodeExpression = outerNodeExpression;
            this.expression = ImmList<BooleanExpression>.FromList(expression);
            this.recursiveQuantifier = recursiveQuantifier;
            this.anchorOnLeft = anchorOnLeft;
        }
    
        public ScriptDom.GraphMatchRecursivePredicate ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchRecursivePredicate();
            ret.Function = function;
            ret.OuterNodeExpression = (ScriptDom.GraphMatchNodeExpression)outerNodeExpression?.ToMutable();
            ret.Expression.AddRange(expression.SelectList(c => (ScriptDom.BooleanExpression)c?.ToMutable()));
            ret.RecursiveQuantifier = (ScriptDom.GraphRecursiveMatchQuantifier)recursiveQuantifier?.ToMutable();
            ret.AnchorOnLeft = anchorOnLeft;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + function.GetHashCode();
            if (!(outerNodeExpression is null)) {
                h = h * 23 + outerNodeExpression.GetHashCode();
            }
            h = h * 23 + expression.GetHashCode();
            if (!(recursiveQuantifier is null)) {
                h = h * 23 + recursiveQuantifier.GetHashCode();
            }
            h = h * 23 + anchorOnLeft.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphMatchRecursivePredicate);
        } 
        
        public bool Equals(GraphMatchRecursivePredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.GraphMatchRecursivePredicateKind>.Default.Equals(other.Function, function)) {
                return false;
            }
            if (!EqualityComparer<GraphMatchNodeExpression>.Default.Equals(other.OuterNodeExpression, outerNodeExpression)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BooleanExpression>>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<GraphRecursiveMatchQuantifier>.Default.Equals(other.RecursiveQuantifier, recursiveQuantifier)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.AnchorOnLeft, anchorOnLeft)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) {
            return EqualityComparer<GraphMatchRecursivePredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphMatchRecursivePredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.function, othr.function);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.outerNodeExpression, othr.outerNodeExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.recursiveQuantifier, othr.recursiveQuantifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.anchorOnLeft, othr.anchorOnLeft);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphMatchRecursivePredicate left, GraphMatchRecursivePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GraphMatchRecursivePredicate FromMutable(ScriptDom.GraphMatchRecursivePredicate fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GraphMatchRecursivePredicate)) { throw new NotImplementedException("Unexpected subtype of GraphMatchRecursivePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchRecursivePredicate(
                function: fragment.Function,
                outerNodeExpression: ImmutableDom.GraphMatchNodeExpression.FromMutable(fragment.OuterNodeExpression),
                expression: fragment.Expression.SelectList(ImmutableDom.BooleanExpression.FromMutable),
                recursiveQuantifier: ImmutableDom.GraphRecursiveMatchQuantifier.FromMutable(fragment.RecursiveQuantifier),
                anchorOnLeft: fragment.AnchorOnLeft
            );
        }
    
    }

}
