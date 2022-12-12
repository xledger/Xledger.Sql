using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WorkloadGroupImportanceParameter : WorkloadGroupParameter, IEquatable<WorkloadGroupImportanceParameter> {
        ScriptDom.ImportanceParameterType parameterValue = ScriptDom.ImportanceParameterType.Unknown;
    
        public ScriptDom.ImportanceParameterType ParameterValue => parameterValue;
    
        public WorkloadGroupImportanceParameter(ScriptDom.ImportanceParameterType parameterValue = ScriptDom.ImportanceParameterType.Unknown, ScriptDom.WorkloadGroupParameterType parameterType = ScriptDom.WorkloadGroupParameterType.Importance) {
            this.parameterValue = parameterValue;
            this.parameterType = parameterType;
        }
    
        public ScriptDom.WorkloadGroupImportanceParameter ToMutableConcrete() {
            var ret = new ScriptDom.WorkloadGroupImportanceParameter();
            ret.ParameterValue = parameterValue;
            ret.ParameterType = parameterType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameterValue.GetHashCode();
            h = h * 23 + parameterType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WorkloadGroupImportanceParameter);
        } 
        
        public bool Equals(WorkloadGroupImportanceParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ImportanceParameterType>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadGroupParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) {
            return EqualityComparer<WorkloadGroupImportanceParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) {
            return !(left == right);
        }
    
    }

}