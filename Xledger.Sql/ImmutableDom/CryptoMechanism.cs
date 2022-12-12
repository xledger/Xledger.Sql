using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CryptoMechanism : TSqlFragment, IEquatable<CryptoMechanism> {
        ScriptDom.CryptoMechanismType cryptoMechanismType = ScriptDom.CryptoMechanismType.Certificate;
        Identifier identifier;
        Literal passwordOrSignature;
    
        public ScriptDom.CryptoMechanismType CryptoMechanismType => cryptoMechanismType;
        public Identifier Identifier => identifier;
        public Literal PasswordOrSignature => passwordOrSignature;
    
        public CryptoMechanism(ScriptDom.CryptoMechanismType cryptoMechanismType = ScriptDom.CryptoMechanismType.Certificate, Identifier identifier = null, Literal passwordOrSignature = null) {
            this.cryptoMechanismType = cryptoMechanismType;
            this.identifier = identifier;
            this.passwordOrSignature = passwordOrSignature;
        }
    
        public ScriptDom.CryptoMechanism ToMutableConcrete() {
            var ret = new ScriptDom.CryptoMechanism();
            ret.CryptoMechanismType = cryptoMechanismType;
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.PasswordOrSignature = (ScriptDom.Literal)passwordOrSignature.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + cryptoMechanismType.GetHashCode();
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            if (!(passwordOrSignature is null)) {
                h = h * 23 + passwordOrSignature.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CryptoMechanism);
        } 
        
        public bool Equals(CryptoMechanism other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CryptoMechanismType>.Default.Equals(other.CryptoMechanismType, cryptoMechanismType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.PasswordOrSignature, passwordOrSignature)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CryptoMechanism left, CryptoMechanism right) {
            return EqualityComparer<CryptoMechanism>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CryptoMechanism left, CryptoMechanism right) {
            return !(left == right);
        }
    
    }

}
