using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAsymmetricKeyStatement : DropUnownedObjectStatement, IEquatable<DropAsymmetricKeyStatement> {
        bool removeProviderKey = false;
    
        public bool RemoveProviderKey => removeProviderKey;
    
        public DropAsymmetricKeyStatement(bool removeProviderKey = false, Identifier name = null, bool isIfExists = false) {
            this.removeProviderKey = removeProviderKey;
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropAsymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropAsymmetricKeyStatement();
            ret.RemoveProviderKey = removeProviderKey;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + removeProviderKey.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropAsymmetricKeyStatement);
        } 
        
        public bool Equals(DropAsymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.RemoveProviderKey, removeProviderKey)) {
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
        
        public static bool operator ==(DropAsymmetricKeyStatement left, DropAsymmetricKeyStatement right) {
            return EqualityComparer<DropAsymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAsymmetricKeyStatement left, DropAsymmetricKeyStatement right) {
            return !(left == right);
        }
    
    }

}
