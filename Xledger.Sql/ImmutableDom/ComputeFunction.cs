using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ComputeFunction : TSqlFragment, IEquatable<ComputeFunction> {
        protected ScriptDom.ComputeFunctionType computeFunctionType = ScriptDom.ComputeFunctionType.NotSpecified;
        protected ScalarExpression expression;
    
        public ScriptDom.ComputeFunctionType ComputeFunctionType => computeFunctionType;
        public ScalarExpression Expression => expression;
    
        public ComputeFunction(ScriptDom.ComputeFunctionType computeFunctionType = ScriptDom.ComputeFunctionType.NotSpecified, ScalarExpression expression = null) {
            this.computeFunctionType = computeFunctionType;
            this.expression = expression;
        }
    
        public ScriptDom.ComputeFunction ToMutableConcrete() {
            var ret = new ScriptDom.ComputeFunction();
            ret.ComputeFunctionType = computeFunctionType;
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + computeFunctionType.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ComputeFunction);
        } 
        
        public bool Equals(ComputeFunction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ComputeFunctionType>.Default.Equals(other.ComputeFunctionType, computeFunctionType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ComputeFunction left, ComputeFunction right) {
            return EqualityComparer<ComputeFunction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ComputeFunction left, ComputeFunction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ComputeFunction)that;
            compare = Comparer.DefaultInvariant.Compare(this.computeFunctionType, othr.computeFunctionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ComputeFunction left, ComputeFunction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ComputeFunction left, ComputeFunction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ComputeFunction left, ComputeFunction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ComputeFunction left, ComputeFunction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
