using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateAsymmetricKeyStatement : TSqlStatement, IEquatable<CreateAsymmetricKeyStatement> {
        Identifier name;
        EncryptionSource keySource;
        ScriptDom.EncryptionAlgorithm encryptionAlgorithm = ScriptDom.EncryptionAlgorithm.None;
        Literal password;
        Identifier owner;
    
        public Identifier Name => name;
        public EncryptionSource KeySource => keySource;
        public ScriptDom.EncryptionAlgorithm EncryptionAlgorithm => encryptionAlgorithm;
        public Literal Password => password;
        public Identifier Owner => owner;
    
        public CreateAsymmetricKeyStatement(Identifier name = null, EncryptionSource keySource = null, ScriptDom.EncryptionAlgorithm encryptionAlgorithm = ScriptDom.EncryptionAlgorithm.None, Literal password = null, Identifier owner = null) {
            this.name = name;
            this.keySource = keySource;
            this.encryptionAlgorithm = encryptionAlgorithm;
            this.password = password;
            this.owner = owner;
        }
    
        public ScriptDom.CreateAsymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateAsymmetricKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.KeySource = (ScriptDom.EncryptionSource)keySource.ToMutable();
            ret.EncryptionAlgorithm = encryptionAlgorithm;
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            if (!(keySource is null)) {
                h = h * 23 + keySource.GetHashCode();
            }
            h = h * 23 + encryptionAlgorithm.GetHashCode();
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateAsymmetricKeyStatement);
        } 
        
        public bool Equals(CreateAsymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<EncryptionSource>.Default.Equals(other.KeySource, keySource)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EncryptionAlgorithm>.Default.Equals(other.EncryptionAlgorithm, encryptionAlgorithm)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateAsymmetricKeyStatement left, CreateAsymmetricKeyStatement right) {
            return EqualityComparer<CreateAsymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateAsymmetricKeyStatement left, CreateAsymmetricKeyStatement right) {
            return !(left == right);
        }
    
    }

}