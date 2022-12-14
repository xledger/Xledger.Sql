using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResourcePoolParameter : TSqlFragment, IEquatable<ResourcePoolParameter> {
        protected ScriptDom.ResourcePoolParameterType parameterType = ScriptDom.ResourcePoolParameterType.Unknown;
        protected Literal parameterValue;
        protected ResourcePoolAffinitySpecification affinitySpecification;
    
        public ScriptDom.ResourcePoolParameterType ParameterType => parameterType;
        public Literal ParameterValue => parameterValue;
        public ResourcePoolAffinitySpecification AffinitySpecification => affinitySpecification;
    
        public ResourcePoolParameter(ScriptDom.ResourcePoolParameterType parameterType = ScriptDom.ResourcePoolParameterType.Unknown, Literal parameterValue = null, ResourcePoolAffinitySpecification affinitySpecification = null) {
            this.parameterType = parameterType;
            this.parameterValue = parameterValue;
            this.affinitySpecification = affinitySpecification;
        }
    
        public ScriptDom.ResourcePoolParameter ToMutableConcrete() {
            var ret = new ScriptDom.ResourcePoolParameter();
            ret.ParameterType = parameterType;
            ret.ParameterValue = (ScriptDom.Literal)parameterValue.ToMutable();
            ret.AffinitySpecification = (ScriptDom.ResourcePoolAffinitySpecification)affinitySpecification.ToMutable();
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
            return Equals(obj as ResourcePoolParameter);
        } 
        
        public bool Equals(ResourcePoolParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ResourcePoolParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<ResourcePoolAffinitySpecification>.Default.Equals(other.AffinitySpecification, affinitySpecification)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResourcePoolParameter left, ResourcePoolParameter right) {
            return EqualityComparer<ResourcePoolParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResourcePoolParameter left, ResourcePoolParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ResourcePoolParameter)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameterType, othr.parameterType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameterValue, othr.parameterValue);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.affinitySpecification, othr.affinitySpecification);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ResourcePoolParameter FromMutable(ScriptDom.ResourcePoolParameter fragment) {
            return (ResourcePoolParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
