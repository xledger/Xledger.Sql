using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ComputeFunction : TSqlFragment, IEquatable<ComputeFunction> {
        ScriptDom.ComputeFunctionType computeFunctionType = ScriptDom.ComputeFunctionType.NotSpecified;
        ScalarExpression expression;
    
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
    
    }

}