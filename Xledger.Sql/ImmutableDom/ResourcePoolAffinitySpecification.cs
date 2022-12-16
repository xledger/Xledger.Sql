using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResourcePoolAffinitySpecification : TSqlFragment, IEquatable<ResourcePoolAffinitySpecification> {
        protected ScriptDom.ResourcePoolAffinityType affinityType = ScriptDom.ResourcePoolAffinityType.None;
        protected Literal parameterValue;
        protected bool isAuto = false;
        protected IReadOnlyList<LiteralRange> poolAffinityRanges;
    
        public ScriptDom.ResourcePoolAffinityType AffinityType => affinityType;
        public Literal ParameterValue => parameterValue;
        public bool IsAuto => isAuto;
        public IReadOnlyList<LiteralRange> PoolAffinityRanges => poolAffinityRanges;
    
        public ResourcePoolAffinitySpecification(ScriptDom.ResourcePoolAffinityType affinityType = ScriptDom.ResourcePoolAffinityType.None, Literal parameterValue = null, bool isAuto = false, IReadOnlyList<LiteralRange> poolAffinityRanges = null) {
            this.affinityType = affinityType;
            this.parameterValue = parameterValue;
            this.isAuto = isAuto;
            this.poolAffinityRanges = ImmList<LiteralRange>.FromList(poolAffinityRanges);
        }
    
        public ScriptDom.ResourcePoolAffinitySpecification ToMutableConcrete() {
            var ret = new ScriptDom.ResourcePoolAffinitySpecification();
            ret.AffinityType = affinityType;
            ret.ParameterValue = (ScriptDom.Literal)parameterValue?.ToMutable();
            ret.IsAuto = isAuto;
            ret.PoolAffinityRanges.AddRange(poolAffinityRanges.SelectList(c => (ScriptDom.LiteralRange)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + affinityType.GetHashCode();
            if (!(parameterValue is null)) {
                h = h * 23 + parameterValue.GetHashCode();
            }
            h = h * 23 + isAuto.GetHashCode();
            h = h * 23 + poolAffinityRanges.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResourcePoolAffinitySpecification);
        } 
        
        public bool Equals(ResourcePoolAffinitySpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ResourcePoolAffinityType>.Default.Equals(other.AffinityType, affinityType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAuto, isAuto)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<LiteralRange>>.Default.Equals(other.PoolAffinityRanges, poolAffinityRanges)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) {
            return EqualityComparer<ResourcePoolAffinitySpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ResourcePoolAffinitySpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.affinityType, othr.affinityType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterValue, othr.parameterValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isAuto, othr.isAuto);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.poolAffinityRanges, othr.poolAffinityRanges);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ResourcePoolAffinitySpecification left, ResourcePoolAffinitySpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
