using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteParameter : TSqlFragment, IEquatable<ExecuteParameter> {
        VariableReference variable;
        ScalarExpression parameterValue;
        bool isOutput = false;
    
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
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.ParameterValue = (ScriptDom.ScalarExpression)parameterValue.ToMutable();
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
    
    }

}