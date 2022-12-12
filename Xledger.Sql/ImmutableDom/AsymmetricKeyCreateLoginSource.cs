using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AsymmetricKeyCreateLoginSource : CreateLoginSource, IEquatable<AsymmetricKeyCreateLoginSource> {
        Identifier key;
        Identifier credential;
    
        public Identifier Key => key;
        public Identifier Credential => credential;
    
        public AsymmetricKeyCreateLoginSource(Identifier key = null, Identifier credential = null) {
            this.key = key;
            this.credential = credential;
        }
    
        public ScriptDom.AsymmetricKeyCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.AsymmetricKeyCreateLoginSource();
            ret.Key = (ScriptDom.Identifier)key.ToMutable();
            ret.Credential = (ScriptDom.Identifier)credential.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(key is null)) {
                h = h * 23 + key.GetHashCode();
            }
            if (!(credential is null)) {
                h = h * 23 + credential.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AsymmetricKeyCreateLoginSource);
        } 
        
        public bool Equals(AsymmetricKeyCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Key, key)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Credential, credential)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AsymmetricKeyCreateLoginSource left, AsymmetricKeyCreateLoginSource right) {
            return EqualityComparer<AsymmetricKeyCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AsymmetricKeyCreateLoginSource left, AsymmetricKeyCreateLoginSource right) {
            return !(left == right);
        }
    
    }

}
