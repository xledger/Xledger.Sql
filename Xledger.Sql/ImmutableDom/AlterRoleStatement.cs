using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterRoleStatement : RoleStatement, IEquatable<AlterRoleStatement> {
        protected AlterRoleAction action;
    
        public AlterRoleAction Action => action;
    
        public AlterRoleStatement(AlterRoleAction action = null, Identifier name = null) {
            this.action = action;
            this.name = name;
        }
    
        public ScriptDom.AlterRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterRoleStatement();
            ret.Action = (ScriptDom.AlterRoleAction)action.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterRoleStatement);
        } 
        
        public bool Equals(AlterRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<AlterRoleAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterRoleStatement left, AlterRoleStatement right) {
            return EqualityComparer<AlterRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterRoleStatement left, AlterRoleStatement right) {
            return !(left == right);
        }
    
    }

}
