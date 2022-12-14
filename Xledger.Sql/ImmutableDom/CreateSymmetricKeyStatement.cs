using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSymmetricKeyStatement : SymmetricKeyStatement, IEquatable<CreateSymmetricKeyStatement> {
        protected IReadOnlyList<KeyOption> keyOptions;
        protected Identifier provider;
        protected Identifier owner;
    
        public IReadOnlyList<KeyOption> KeyOptions => keyOptions;
        public Identifier Provider => provider;
        public Identifier Owner => owner;
    
        public CreateSymmetricKeyStatement(IReadOnlyList<KeyOption> keyOptions = null, Identifier provider = null, Identifier owner = null, Identifier name = null, IReadOnlyList<CryptoMechanism> encryptingMechanisms = null) {
            this.keyOptions = ImmList<KeyOption>.FromList(keyOptions);
            this.provider = provider;
            this.owner = owner;
            this.name = name;
            this.encryptingMechanisms = ImmList<CryptoMechanism>.FromList(encryptingMechanisms);
        }
    
        public ScriptDom.CreateSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSymmetricKeyStatement();
            ret.KeyOptions.AddRange(keyOptions.SelectList(c => (ScriptDom.KeyOption)c?.ToMutable()));
            ret.Provider = (ScriptDom.Identifier)provider?.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.EncryptingMechanisms.AddRange(encryptingMechanisms.SelectList(c => (ScriptDom.CryptoMechanism)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + keyOptions.GetHashCode();
            if (!(provider is null)) {
                h = h * 23 + provider.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + encryptingMechanisms.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSymmetricKeyStatement);
        } 
        
        public bool Equals(CreateSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<KeyOption>>.Default.Equals(other.KeyOptions, keyOptions)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Provider, provider)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
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
        
        public static bool operator ==(CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) {
            return EqualityComparer<CreateSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSymmetricKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.keyOptions, othr.keyOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.provider, othr.provider);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.encryptingMechanisms, othr.encryptingMechanisms);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSymmetricKeyStatement left, CreateSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSymmetricKeyStatement FromMutable(ScriptDom.CreateSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSymmetricKeyStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSymmetricKeyStatement(
                keyOptions: fragment.KeyOptions.SelectList(ImmutableDom.KeyOption.FromMutable),
                provider: ImmutableDom.Identifier.FromMutable(fragment.Provider),
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                encryptingMechanisms: fragment.EncryptingMechanisms.SelectList(ImmutableDom.CryptoMechanism.FromMutable)
            );
        }
    
    }

}
