using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterLoginEnableDisableStatement : AlterLoginStatement, IEquatable<AlterLoginEnableDisableStatement> {
        bool isEnable = false;
    
        public bool IsEnable => isEnable;
    
        public AlterLoginEnableDisableStatement(bool isEnable = false, Identifier name = null) {
            this.isEnable = isEnable;
            this.name = name;
        }
    
        public ScriptDom.AlterLoginEnableDisableStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterLoginEnableDisableStatement();
            ret.IsEnable = isEnable;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isEnable.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterLoginEnableDisableStatement);
        } 
        
        public bool Equals(AlterLoginEnableDisableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsEnable, isEnable)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterLoginEnableDisableStatement left, AlterLoginEnableDisableStatement right) {
            return EqualityComparer<AlterLoginEnableDisableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterLoginEnableDisableStatement left, AlterLoginEnableDisableStatement right) {
            return !(left == right);
        }
    
    }

}
