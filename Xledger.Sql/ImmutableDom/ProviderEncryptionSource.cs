using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProviderEncryptionSource : EncryptionSource, IEquatable<ProviderEncryptionSource> {
        protected Identifier name;
        protected IReadOnlyList<KeyOption> keyOptions;
    
        public Identifier Name => name;
        public IReadOnlyList<KeyOption> KeyOptions => keyOptions;
    
        public ProviderEncryptionSource(Identifier name = null, IReadOnlyList<KeyOption> keyOptions = null) {
            this.name = name;
            this.keyOptions = ImmList<KeyOption>.FromList(keyOptions);
        }
    
        public ScriptDom.ProviderEncryptionSource ToMutableConcrete() {
            var ret = new ScriptDom.ProviderEncryptionSource();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.KeyOptions.AddRange(keyOptions.SelectList(c => (ScriptDom.KeyOption)c?.ToMutable()));
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
            h = h * 23 + keyOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ProviderEncryptionSource);
        } 
        
        public bool Equals(ProviderEncryptionSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<KeyOption>>.Default.Equals(other.KeyOptions, keyOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProviderEncryptionSource left, ProviderEncryptionSource right) {
            return EqualityComparer<ProviderEncryptionSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProviderEncryptionSource left, ProviderEncryptionSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ProviderEncryptionSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.keyOptions, othr.keyOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ProviderEncryptionSource left, ProviderEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ProviderEncryptionSource left, ProviderEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ProviderEncryptionSource left, ProviderEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ProviderEncryptionSource left, ProviderEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
