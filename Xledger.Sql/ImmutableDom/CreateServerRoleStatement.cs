using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateServerRoleStatement : CreateRoleStatement, IEquatable<CreateServerRoleStatement> {
        public CreateServerRoleStatement(Identifier owner = null, Identifier name = null) {
            this.owner = owner;
            this.name = name;
        }
    
        public ScriptDom.CreateServerRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServerRoleStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateServerRoleStatement);
        } 
        
        public bool Equals(CreateServerRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateServerRoleStatement left, CreateServerRoleStatement right) {
            return EqualityComparer<CreateServerRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateServerRoleStatement left, CreateServerRoleStatement right) {
            return !(left == right);
        }
    
        public static CreateServerRoleStatement FromMutable(ScriptDom.CreateServerRoleStatement fragment) {
            return (CreateServerRoleStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
