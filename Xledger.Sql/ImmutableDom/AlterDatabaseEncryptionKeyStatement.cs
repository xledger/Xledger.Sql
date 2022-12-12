using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement, IEquatable<AlterDatabaseEncryptionKeyStatement> {
        protected bool regenerate = false;
    
        public bool Regenerate => regenerate;
    
        public AlterDatabaseEncryptionKeyStatement(bool regenerate = false, CryptoMechanism encryptor = null, ScriptDom.DatabaseEncryptionKeyAlgorithm algorithm = ScriptDom.DatabaseEncryptionKeyAlgorithm.None) {
            this.regenerate = regenerate;
            this.encryptor = encryptor;
            this.algorithm = algorithm;
        }
    
        public ScriptDom.AlterDatabaseEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseEncryptionKeyStatement();
            ret.Regenerate = regenerate;
            ret.Encryptor = (ScriptDom.CryptoMechanism)encryptor.ToMutable();
            ret.Algorithm = algorithm;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + regenerate.GetHashCode();
            if (!(encryptor is null)) {
                h = h * 23 + encryptor.GetHashCode();
            }
            h = h * 23 + algorithm.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseEncryptionKeyStatement);
        } 
        
        public bool Equals(AlterDatabaseEncryptionKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Regenerate, regenerate)) {
                return false;
            }
            if (!EqualityComparer<CryptoMechanism>.Default.Equals(other.Encryptor, encryptor)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseEncryptionKeyAlgorithm>.Default.Equals(other.Algorithm, algorithm)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) {
            return EqualityComparer<AlterDatabaseEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) {
            return !(left == right);
        }
    
    }

}
