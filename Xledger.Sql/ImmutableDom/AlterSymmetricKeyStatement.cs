using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterSymmetricKeyStatement : SymmetricKeyStatement, IEquatable<AlterSymmetricKeyStatement> {
        protected bool isAdd = false;
    
        public bool IsAdd => isAdd;
    
        public AlterSymmetricKeyStatement(bool isAdd = false, Identifier name = null, IReadOnlyList<CryptoMechanism> encryptingMechanisms = null) {
            this.isAdd = isAdd;
            this.name = name;
            this.encryptingMechanisms = encryptingMechanisms is null ? ImmList<CryptoMechanism>.Empty : ImmList<CryptoMechanism>.FromList(encryptingMechanisms);
        }
    
        public ScriptDom.AlterSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterSymmetricKeyStatement();
            ret.IsAdd = isAdd;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.EncryptingMechanisms.AddRange(encryptingMechanisms.SelectList(c => (ScriptDom.CryptoMechanism)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isAdd.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + encryptingMechanisms.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterSymmetricKeyStatement);
        } 
        
        public bool Equals(AlterSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAdd, isAdd)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CryptoMechanism>>.Default.Equals(other.EncryptingMechanisms, encryptingMechanisms)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterSymmetricKeyStatement left, AlterSymmetricKeyStatement right) {
            return EqualityComparer<AlterSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterSymmetricKeyStatement left, AlterSymmetricKeyStatement right) {
            return !(left == right);
        }
    
    }

}
