using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterCertificateStatement : CertificateStatementBase, IEquatable<AlterCertificateStatement> {
        ScriptDom.AlterCertificateStatementKind kind = ScriptDom.AlterCertificateStatementKind.None;
        Literal attestedBy;
    
        public ScriptDom.AlterCertificateStatementKind Kind => kind;
        public Literal AttestedBy => attestedBy;
    
        public AlterCertificateStatement(ScriptDom.AlterCertificateStatementKind kind = ScriptDom.AlterCertificateStatementKind.None, Literal attestedBy = null, Identifier name = null, ScriptDom.OptionState activeForBeginDialog = ScriptDom.OptionState.NotSet, Literal privateKeyPath = null, Literal encryptionPassword = null, Literal decryptionPassword = null) {
            this.kind = kind;
            this.attestedBy = attestedBy;
            this.name = name;
            this.activeForBeginDialog = activeForBeginDialog;
            this.privateKeyPath = privateKeyPath;
            this.encryptionPassword = encryptionPassword;
            this.decryptionPassword = decryptionPassword;
        }
    
        public ScriptDom.AlterCertificateStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterCertificateStatement();
            ret.Kind = kind;
            ret.AttestedBy = (ScriptDom.Literal)attestedBy.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ActiveForBeginDialog = activeForBeginDialog;
            ret.PrivateKeyPath = (ScriptDom.Literal)privateKeyPath.ToMutable();
            ret.EncryptionPassword = (ScriptDom.Literal)encryptionPassword.ToMutable();
            ret.DecryptionPassword = (ScriptDom.Literal)decryptionPassword.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + kind.GetHashCode();
            if (!(attestedBy is null)) {
                h = h * 23 + attestedBy.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + activeForBeginDialog.GetHashCode();
            if (!(privateKeyPath is null)) {
                h = h * 23 + privateKeyPath.GetHashCode();
            }
            if (!(encryptionPassword is null)) {
                h = h * 23 + encryptionPassword.GetHashCode();
            }
            if (!(decryptionPassword is null)) {
                h = h * 23 + decryptionPassword.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterCertificateStatement);
        } 
        
        public bool Equals(AlterCertificateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterCertificateStatementKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.AttestedBy, attestedBy)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.ActiveForBeginDialog, activeForBeginDialog)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.PrivateKeyPath, privateKeyPath)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.EncryptionPassword, encryptionPassword)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.DecryptionPassword, decryptionPassword)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterCertificateStatement left, AlterCertificateStatement right) {
            return EqualityComparer<AlterCertificateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterCertificateStatement left, AlterCertificateStatement right) {
            return !(left == right);
        }
    
    }

}