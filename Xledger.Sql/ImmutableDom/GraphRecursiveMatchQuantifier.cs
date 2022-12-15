using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphRecursiveMatchQuantifier : BooleanExpression, IEquatable<GraphRecursiveMatchQuantifier> {
        protected bool isPlusSign = false;
        protected Literal lowerLimit;
        protected Literal upperLimit;
    
        public bool IsPlusSign => isPlusSign;
        public Literal LowerLimit => lowerLimit;
        public Literal UpperLimit => upperLimit;
    
        public GraphRecursiveMatchQuantifier(bool isPlusSign = false, Literal lowerLimit = null, Literal upperLimit = null) {
            this.isPlusSign = isPlusSign;
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
        }
    
        public ScriptDom.GraphRecursiveMatchQuantifier ToMutableConcrete() {
            var ret = new ScriptDom.GraphRecursiveMatchQuantifier();
            ret.IsPlusSign = isPlusSign;
            ret.LowerLimit = (ScriptDom.Literal)lowerLimit.ToMutable();
            ret.UpperLimit = (ScriptDom.Literal)upperLimit.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isPlusSign.GetHashCode();
            if (!(lowerLimit is null)) {
                h = h * 23 + lowerLimit.GetHashCode();
            }
            if (!(upperLimit is null)) {
                h = h * 23 + upperLimit.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphRecursiveMatchQuantifier);
        } 
        
        public bool Equals(GraphRecursiveMatchQuantifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsPlusSign, isPlusSign)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.LowerLimit, lowerLimit)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.UpperLimit, upperLimit)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) {
            return EqualityComparer<GraphRecursiveMatchQuantifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GraphRecursiveMatchQuantifier)that;
            compare = Comparer.DefaultInvariant.Compare(this.isPlusSign, othr.isPlusSign);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.lowerLimit, othr.lowerLimit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.upperLimit, othr.upperLimit);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GraphRecursiveMatchQuantifier left, GraphRecursiveMatchQuantifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
