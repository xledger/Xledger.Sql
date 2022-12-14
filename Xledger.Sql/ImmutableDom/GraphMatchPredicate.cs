using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphMatchPredicate : BooleanExpression, IEquatable<GraphMatchPredicate> {
        protected BooleanExpression expression;
    
        public BooleanExpression Expression => expression;
    
        public GraphMatchPredicate(BooleanExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.GraphMatchPredicate ToMutableConcrete() {
            var ret = new ScriptDom.GraphMatchPredicate();
            ret.Expression = (ScriptDom.BooleanExpression)expression?.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphMatchPredicate);
        } 
        
        public bool Equals(GraphMatchPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphMatchPredicate left, GraphMatchPredicate right) {
            return EqualityComparer<GraphMatchPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphMatchPredicate left, GraphMatchPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphMatchPredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (GraphMatchPredicate left, GraphMatchPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphMatchPredicate left, GraphMatchPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphMatchPredicate left, GraphMatchPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphMatchPredicate left, GraphMatchPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GraphMatchPredicate FromMutable(ScriptDom.GraphMatchPredicate fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GraphMatchPredicate)) { throw new NotImplementedException("Unexpected subtype of GraphMatchPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchPredicate(
                expression: ImmutableDom.BooleanExpression.FromMutable(fragment.Expression)
            );
        }
    
    }

}
