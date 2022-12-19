using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WorkloadGroupImportanceParameter : WorkloadGroupParameter, IEquatable<WorkloadGroupImportanceParameter> {
        protected ScriptDom.ImportanceParameterType parameterValue = ScriptDom.ImportanceParameterType.Unknown;
    
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WorkloadGroupImportanceParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameterValue, othr.parameterValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterType, othr.parameterType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WorkloadGroupImportanceParameter left, WorkloadGroupImportanceParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static WorkloadGroupImportanceParameter FromMutable(ScriptDom.WorkloadGroupImportanceParameter fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.WorkloadGroupImportanceParameter)) { throw new NotImplementedException("Unexpected subtype of WorkloadGroupImportanceParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WorkloadGroupImportanceParameter(
                parameterValue: fragment.ParameterValue,
                parameterType: fragment.ParameterType
            );
        }
    
    }

}
