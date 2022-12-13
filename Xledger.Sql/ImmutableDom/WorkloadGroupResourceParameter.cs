using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WorkloadGroupResourceParameter : WorkloadGroupParameter, IEquatable<WorkloadGroupResourceParameter> {
        protected Literal parameterValue;
    
        public Literal ParameterValue => parameterValue;
    
        public WorkloadGroupResourceParameter(Literal parameterValue = null, ScriptDom.WorkloadGroupParameterType parameterType = ScriptDom.WorkloadGroupParameterType.Importance) {
            this.parameterValue = parameterValue;
            this.parameterType = parameterType;
        }
    
        public ScriptDom.WorkloadGroupResourceParameter ToMutableConcrete() {
            var ret = new ScriptDom.WorkloadGroupResourceParameter();
            ret.ParameterValue = (ScriptDom.Literal)parameterValue.ToMutable();
            ret.ParameterType = parameterType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(parameterValue is null)) {
                h = h * 23 + parameterValue.GetHashCode();
            }
            h = h * 23 + parameterType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WorkloadGroupResourceParameter);
        } 
        
        public bool Equals(WorkloadGroupResourceParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadGroupParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WorkloadGroupResourceParameter left, WorkloadGroupResourceParameter right) {
            return EqualityComparer<WorkloadGroupResourceParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WorkloadGroupResourceParameter left, WorkloadGroupResourceParameter right) {
            return !(left == right);
        }
    
        public static WorkloadGroupResourceParameter FromMutable(ScriptDom.WorkloadGroupResourceParameter fragment) {
            return (WorkloadGroupResourceParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
