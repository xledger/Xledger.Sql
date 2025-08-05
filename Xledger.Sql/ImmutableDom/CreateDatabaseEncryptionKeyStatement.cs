using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement, IEquatable<CreateDatabaseEncryptionKeyStatement> {
        public CreateDatabaseEncryptionKeyStatement(CryptoMechanism encryptor = null, ScriptDom.DatabaseEncryptionKeyAlgorithm algorithm = ScriptDom.DatabaseEncryptionKeyAlgorithm.None) {
            this.encryptor = encryptor;
            this.algorithm = algorithm;
        }
    
        public ScriptDom.CreateDatabaseEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateDatabaseEncryptionKeyStatement();
            ret.Encryptor = (ScriptDom.CryptoMechanism)encryptor?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateDatabaseEncryptionKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.encryptor, othr.encryptor);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.algorithm, othr.algorithm);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateDatabaseEncryptionKeyStatement left, CreateDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateDatabaseEncryptionKeyStatement FromMutable(ScriptDom.CreateDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateDatabaseEncryptionKeyStatement)) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseEncryptionKeyStatement(
                encryptor: ImmutableDom.CryptoMechanism.FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
    
    }

}
