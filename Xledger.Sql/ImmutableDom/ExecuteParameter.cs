using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteParameter : TSqlFragment, IEquatable<ExecuteParameter> {
        protected VariableReference variable;
        protected ScalarExpression parameterValue;
        protected bool isOutput = false;
    
        public VariableReference Variable => variable;
        public ScalarExpression ParameterValue => parameterValue;
        public bool IsOutput => isOutput;
    
        public ExecuteParameter(VariableReference variable = null, ScalarExpression parameterValue = null, bool isOutput = false) {
            this.variable = variable;
            this.parameterValue = parameterValue;
            this.isOutput = isOutput;
        }
    
        public ScriptDom.ExecuteParameter ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteParameter();
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.ParameterValue = (ScriptDom.ScalarExpression)parameterValue?.ToMutable();
            ret.IsOutput = isOutput;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variable is null)) {
                h = h * 23 + variable.GetHashCode();
            }
            if (!(parameterValue is null)) {
                h = h * 23 + parameterValue.GetHashCode();
            }
            h = h * 23 + isOutput.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteParameter);
        } 
        
        public bool Equals(ExecuteParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOutput, isOutput)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteParameter left, ExecuteParameter right) {
            return EqualityComparer<ExecuteParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteParameter left, ExecuteParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterValue, othr.parameterValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isOutput, othr.isOutput);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecuteParameter left, ExecuteParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecuteParameter left, ExecuteParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecuteParameter left, ExecuteParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecuteParameter left, ExecuteParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecuteParameter FromMutable(ScriptDom.ExecuteParameter fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecuteParameter)) { throw new NotImplementedException("Unexpected subtype of ExecuteParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteParameter(
                variable: ImmutableDom.VariableReference.FromMutable(fragment.Variable),
                parameterValue: ImmutableDom.ScalarExpression.FromMutable(fragment.ParameterValue),
                isOutput: fragment.IsOutput
            );
        }
    
    }

}
