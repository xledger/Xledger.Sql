using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuthenticationPayloadOption : PayloadOption, IEquatable<AuthenticationPayloadOption> {
        protected ScriptDom.AuthenticationProtocol protocol = ScriptDom.AuthenticationProtocol.NotSpecified;
        protected Identifier certificate;
        protected bool tryCertificateFirst = false;
    
        public ScriptDom.AuthenticationProtocol Protocol => protocol;
        public Identifier Certificate => certificate;
        public bool TryCertificateFirst => tryCertificateFirst;
    
        public AuthenticationPayloadOption(ScriptDom.AuthenticationProtocol protocol = ScriptDom.AuthenticationProtocol.NotSpecified, Identifier certificate = null, bool tryCertificateFirst = false, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.protocol = protocol;
            this.certificate = certificate;
            this.tryCertificateFirst = tryCertificateFirst;
            this.kind = kind;
        }
    
        public ScriptDom.AuthenticationPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.AuthenticationPayloadOption();
            ret.Protocol = protocol;
            ret.Certificate = (ScriptDom.Identifier)certificate.ToMutable();
            ret.TryCertificateFirst = tryCertificateFirst;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + protocol.GetHashCode();
            if (!(certificate is null)) {
                h = h * 23 + certificate.GetHashCode();
            }
            h = h * 23 + tryCertificateFirst.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuthenticationPayloadOption);
        } 
        
        public bool Equals(AuthenticationPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AuthenticationProtocol>.Default.Equals(other.Protocol, protocol)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Certificate, certificate)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.TryCertificateFirst, tryCertificateFirst)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuthenticationPayloadOption left, AuthenticationPayloadOption right) {
            return EqualityComparer<AuthenticationPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuthenticationPayloadOption left, AuthenticationPayloadOption right) {
            return !(left == right);
        }
    
        public static AuthenticationPayloadOption FromMutable(ScriptDom.AuthenticationPayloadOption fragment) {
            return (AuthenticationPayloadOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
