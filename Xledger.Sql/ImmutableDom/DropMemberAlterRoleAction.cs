using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropMemberAlterRoleAction : AlterRoleAction, IEquatable<DropMemberAlterRoleAction> {
        Identifier member;
    
        public Identifier Member => member;
    
        public DropMemberAlterRoleAction(Identifier member = null) {
            this.member = member;
        }
    
        public ScriptDom.DropMemberAlterRoleAction ToMutableConcrete() {
            var ret = new ScriptDom.DropMemberAlterRoleAction();
            ret.Member = (ScriptDom.Identifier)member.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(member is null)) {
                h = h * 23 + member.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropMemberAlterRoleAction);
        } 
        
        public bool Equals(DropMemberAlterRoleAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Member, member)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropMemberAlterRoleAction left, DropMemberAlterRoleAction right) {
            return EqualityComparer<DropMemberAlterRoleAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropMemberAlterRoleAction left, DropMemberAlterRoleAction right) {
            return !(left == right);
        }
    
    }

}
