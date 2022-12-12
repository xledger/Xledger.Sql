using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateRoleStatement : RoleStatement, IEquatable<CreateRoleStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateRoleStatement(Identifier owner = null, Identifier name = null) {
            this.owner = owner;
            this.name = name;
        }
    
        public ScriptDom.CreateRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateRoleStatement();
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
            return Equals(obj as CreateRoleStatement);
        } 
        
        public bool Equals(CreateRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateRoleStatement left, CreateRoleStatement right) {
            return EqualityComparer<CreateRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateRoleStatement left, CreateRoleStatement right) {
            return !(left == right);
        }
    
    }

}
