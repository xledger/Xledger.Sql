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
            this.keyOptions = keyOptions is null ? ImmList<KeyOption>.Empty : ImmList<KeyOption>.FromList(keyOptions);
        }
    
        public ScriptDom.ProviderEncryptionSource ToMutableConcrete() {
            var ret = new ScriptDom.ProviderEncryptionSource();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.KeyOptions.AddRange(keyOptions.SelectList(c => (ScriptDom.KeyOption)c.ToMutable()));
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
    
        public static ProviderEncryptionSource FromMutable(ScriptDom.ProviderEncryptionSource fragment) {
            return (ProviderEncryptionSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
