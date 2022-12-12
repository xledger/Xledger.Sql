using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CertificateOption : TSqlFragment, IEquatable<CertificateOption> {
        protected ScriptDom.CertificateOptionKinds kind = ScriptDom.CertificateOptionKinds.None;
        protected Literal @value;
    
        public ScriptDom.CertificateOptionKinds Kind => kind;
        public Literal Value => @value;
    
        public CertificateOption(ScriptDom.CertificateOptionKinds kind = ScriptDom.CertificateOptionKinds.None, Literal @value = null) {
            this.kind = kind;
            this.@value = @value;
        }
    
        public ScriptDom.CertificateOption ToMutableConcrete() {
            var ret = new ScriptDom.CertificateOption();
            ret.Kind = kind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + kind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CertificateOption);
        } 
        
        public bool Equals(CertificateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CertificateOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CertificateOption left, CertificateOption right) {
            return EqualityComparer<CertificateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CertificateOption left, CertificateOption right) {
            return !(left == right);
        }
    
    }

}
