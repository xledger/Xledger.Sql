using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalResourcePoolParameter : TSqlFragment, IEquatable<ExternalResourcePoolParameter> {
        ScriptDom.ExternalResourcePoolParameterType parameterType = ScriptDom.ExternalResourcePoolParameterType.Unknown;
        Literal parameterValue;
        ExternalResourcePoolAffinitySpecification affinitySpecification;
    
        public ScriptDom.ExternalResourcePoolParameterType ParameterType => parameterType;
        public Literal ParameterValue => parameterValue;
        public ExternalResourcePoolAffinitySpecification AffinitySpecification => affinitySpecification;
    
        public ExternalResourcePoolParameter(ScriptDom.ExternalResourcePoolParameterType parameterType = ScriptDom.ExternalResourcePoolParameterType.Unknown, Literal parameterValue = null, ExternalResourcePoolAffinitySpecification affinitySpecification = null) {
            this.parameterType = parameterType;
            this.parameterValue = parameterValue;
            this.affinitySpecification = affinitySpecification;
        }
    
        public ScriptDom.ExternalResourcePoolParameter ToMutableConcrete() {
            var ret = new ScriptDom.ExternalResourcePoolParameter();
            ret.ParameterType = parameterType;
            ret.ParameterValue = (ScriptDom.Literal)parameterValue.ToMutable();
            ret.AffinitySpecification = (ScriptDom.ExternalResourcePoolAffinitySpecification)affinitySpecification.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameterType.GetHashCode();
            if (!(parameterValue is null)) {
                h = h * 23 + parameterValue.GetHashCode();
            }
            if (!(affinitySpecification is null)) {
                h = h * 23 + affinitySpecification.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalResourcePoolParameter);
        } 
        
        public bool Equals(ExternalResourcePoolParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExternalResourcePoolParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<ExternalResourcePoolAffinitySpecification>.Default.Equals(other.AffinitySpecification, affinitySpecification)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalResourcePoolParameter left, ExternalResourcePoolParameter right) {
            return EqualityComparer<ExternalResourcePoolParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalResourcePoolParameter left, ExternalResourcePoolParameter right) {
            return !(left == right);
        }
    
    }

}
