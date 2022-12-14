using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResourcePoolStatement : TSqlStatement, IEquatable<ResourcePoolStatement> {
        protected Identifier name;
        protected IReadOnlyList<ResourcePoolParameter> resourcePoolParameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ResourcePoolParameter> ResourcePoolParameters => resourcePoolParameters;
    
        public ResourcePoolStatement(Identifier name = null, IReadOnlyList<ResourcePoolParameter> resourcePoolParameters = null) {
            this.name = name;
            this.resourcePoolParameters = ImmList<ResourcePoolParameter>.FromList(resourcePoolParameters);
        }
    
        public ScriptDom.ResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.ResourcePoolStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ResourcePoolParameters.AddRange(resourcePoolParameters.SelectList(c => (ScriptDom.ResourcePoolParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + resourcePoolParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResourcePoolStatement);
        } 
        
        public bool Equals(ResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ResourcePoolParameter>>.Default.Equals(other.ResourcePoolParameters, resourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResourcePoolStatement left, ResourcePoolStatement right) {
            return EqualityComparer<ResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResourcePoolStatement left, ResourcePoolStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ResourcePoolStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.resourcePoolParameters, othr.resourcePoolParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ResourcePoolStatement FromMutable(ScriptDom.ResourcePoolStatement fragment) {
            return (ResourcePoolStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
