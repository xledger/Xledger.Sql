using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CertificateCreateLoginSource : CreateLoginSource, IEquatable<CertificateCreateLoginSource> {
        Identifier certificate;
        Identifier credential;
    
        public Identifier Certificate => certificate;
        public Identifier Credential => credential;
    
        public CertificateCreateLoginSource(Identifier certificate = null, Identifier credential = null) {
            this.certificate = certificate;
            this.credential = credential;
        }
    
        public ScriptDom.CertificateCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.CertificateCreateLoginSource();
            ret.Certificate = (ScriptDom.Identifier)certificate.ToMutable();
            ret.Credential = (ScriptDom.Identifier)credential.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(certificate is null)) {
                h = h * 23 + certificate.GetHashCode();
            }
            if (!(credential is null)) {
                h = h * 23 + credential.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CertificateCreateLoginSource);
        } 
        
        public bool Equals(CertificateCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Certificate, certificate)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Credential, credential)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CertificateCreateLoginSource left, CertificateCreateLoginSource right) {
            return EqualityComparer<CertificateCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CertificateCreateLoginSource left, CertificateCreateLoginSource right) {
            return !(left == right);
        }
    
    }

}
