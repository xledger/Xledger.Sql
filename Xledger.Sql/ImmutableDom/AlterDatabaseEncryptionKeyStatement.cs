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
            ret.Encryptor = (ScriptDom.CryptoMechanism)encryptor?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseEncryptionKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.regenerate, othr.regenerate);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.encryptor, othr.encryptor);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.algorithm, othr.algorithm);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseEncryptionKeyStatement left, AlterDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabaseEncryptionKeyStatement FromMutable(ScriptDom.AlterDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabaseEncryptionKeyStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseEncryptionKeyStatement(
                regenerate: fragment.Regenerate,
                encryptor: ImmutableDom.CryptoMechanism.FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
    
    }

}
