using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement, IEquatable<CreateDatabaseEncryptionKeyStatement> {
        public CreateDatabaseEncryptionKeyStatement(CryptoMechanism encryptor = null, ScriptDom.DatabaseEncryptionKeyAlgorithm algorithm = ScriptDom.DatabaseEncryptionKeyAlgorithm.None) {
            this.encryptor = encryptor;
            this.algorithm = algorithm;
        }
    
        public ScriptDom.CreateDatabaseEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateDatabaseEncryptionKeyStatement();
            ret.Encryptor = (ScriptDom.CryptoMechanism)encryptor.ToMutable();
            ret.Algorithm = algorithm;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(encryptor is null)) {
                h = h * 23 + encryptor.GetHashCode();
            }
            h = h * 23 + algorithm.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateDatabaseEncryptionKeyStatement);
        } 
        
        public bool Equals(CreateDatabaseEncryptionKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<CryptoMechanism>.Default.Equals(other.Encryptor, encryptor)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseEncryptionKeyAlgorithm>.Default.Equals(other.Algorithm, algorithm)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) {
            return EqualityComparer<CreateDatabaseEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) {
            return !(left == right);
        }
    
        public static CreateDatabaseEncryptionKeyStatement FromMutable(ScriptDom.CreateDatabaseEncryptionKeyStatement fragment) {
            return (CreateDatabaseEncryptionKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
