using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropCredentialStatement : DropUnownedObjectStatement, IEquatable<DropCredentialStatement> {
        bool isDatabaseScoped = false;
    
        public bool IsDatabaseScoped => isDatabaseScoped;
    
        public DropCredentialStatement(bool isDatabaseScoped = false, Identifier name = null, bool isIfExists = false) {
            this.isDatabaseScoped = isDatabaseScoped;
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropCredentialStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropCredentialStatement();
            ret.IsDatabaseScoped = isDatabaseScoped;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isDatabaseScoped.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropCredentialStatement);
        } 
        
        public bool Equals(DropCredentialStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDatabaseScoped, isDatabaseScoped)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropCredentialStatement left, DropCredentialStatement right) {
            return EqualityComparer<DropCredentialStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropCredentialStatement left, DropCredentialStatement right) {
            return !(left == right);
        }
    
    }

}