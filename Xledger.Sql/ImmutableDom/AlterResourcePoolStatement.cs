using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterResourcePoolStatement : ResourcePoolStatement, IEquatable<AlterResourcePoolStatement> {
        public AlterResourcePoolStatement(Identifier name = null, IReadOnlyList<ResourcePoolParameter> resourcePoolParameters = null) {
            this.name = name;
            this.resourcePoolParameters = resourcePoolParameters is null ? ImmList<ResourcePoolParameter>.Empty : ImmList<ResourcePoolParameter>.FromList(resourcePoolParameters);
        }
    
        public ScriptDom.AlterResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterResourcePoolStatement();
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
            return Equals(obj as AlterResourcePoolStatement);
        } 
        
        public bool Equals(AlterResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ResourcePoolParameter>>.Default.Equals(other.ResourcePoolParameters, resourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterResourcePoolStatement left, AlterResourcePoolStatement right) {
            return EqualityComparer<AlterResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterResourcePoolStatement left, AlterResourcePoolStatement right) {
            return !(left == right);
        }
    
        public static AlterResourcePoolStatement FromMutable(ScriptDom.AlterResourcePoolStatement fragment) {
            return (AlterResourcePoolStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
