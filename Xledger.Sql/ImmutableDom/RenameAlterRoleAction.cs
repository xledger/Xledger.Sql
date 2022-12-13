using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RenameAlterRoleAction : AlterRoleAction, IEquatable<RenameAlterRoleAction> {
        protected Identifier newName;
    
        public Identifier NewName => newName;
    
        public RenameAlterRoleAction(Identifier newName = null) {
            this.newName = newName;
        }
    
        public ScriptDom.RenameAlterRoleAction ToMutableConcrete() {
            var ret = new ScriptDom.RenameAlterRoleAction();
            ret.NewName = (ScriptDom.Identifier)newName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(newName is null)) {
                h = h * 23 + newName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RenameAlterRoleAction);
        } 
        
        public bool Equals(RenameAlterRoleAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.NewName, newName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RenameAlterRoleAction left, RenameAlterRoleAction right) {
            return EqualityComparer<RenameAlterRoleAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RenameAlterRoleAction left, RenameAlterRoleAction right) {
            return !(left == right);
        }
    
        public static RenameAlterRoleAction FromMutable(ScriptDom.RenameAlterRoleAction fragment) {
            return (RenameAlterRoleAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
