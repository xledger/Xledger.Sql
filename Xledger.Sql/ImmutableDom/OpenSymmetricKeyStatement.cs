using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenSymmetricKeyStatement : TSqlStatement, IEquatable<OpenSymmetricKeyStatement> {
        protected Identifier name;
        protected CryptoMechanism decryptionMechanism;
    
        public Identifier Name => name;
        public CryptoMechanism DecryptionMechanism => decryptionMechanism;
    
        public OpenSymmetricKeyStatement(Identifier name = null, CryptoMechanism decryptionMechanism = null) {
            this.name = name;
            this.decryptionMechanism = decryptionMechanism;
        }
    
        public ScriptDom.OpenSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.OpenSymmetricKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.DecryptionMechanism = (ScriptDom.CryptoMechanism)decryptionMechanism.ToMutable();
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
            if (!(decryptionMechanism is null)) {
                h = h * 23 + decryptionMechanism.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenSymmetricKeyStatement);
        } 
        
        public bool Equals(OpenSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<CryptoMechanism>.Default.Equals(other.DecryptionMechanism, decryptionMechanism)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenSymmetricKeyStatement left, OpenSymmetricKeyStatement right) {
            return EqualityComparer<OpenSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenSymmetricKeyStatement left, OpenSymmetricKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenSymmetricKeyStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.decryptionMechanism, othr.decryptionMechanism);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OpenSymmetricKeyStatement FromMutable(ScriptDom.OpenSymmetricKeyStatement fragment) {
            return (OpenSymmetricKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
