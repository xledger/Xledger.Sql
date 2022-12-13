using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateCertificateStatement : CertificateStatementBase, IEquatable<CreateCertificateStatement> {
        protected EncryptionSource certificateSource;
        protected IReadOnlyList<CertificateOption> certificateOptions;
        protected Identifier owner;
    
        public EncryptionSource CertificateSource => certificateSource;
        public IReadOnlyList<CertificateOption> CertificateOptions => certificateOptions;
        public Identifier Owner => owner;
    
        public CreateCertificateStatement(EncryptionSource certificateSource = null, IReadOnlyList<CertificateOption> certificateOptions = null, Identifier owner = null, Identifier name = null, ScriptDom.OptionState activeForBeginDialog = ScriptDom.OptionState.NotSet, Literal privateKeyPath = null, Literal encryptionPassword = null, Literal decryptionPassword = null) {
            this.certificateSource = certificateSource;
            this.certificateOptions = certificateOptions is null ? ImmList<CertificateOption>.Empty : ImmList<CertificateOption>.FromList(certificateOptions);
            this.owner = owner;
            this.name = name;
            this.activeForBeginDialog = activeForBeginDialog;
            this.privateKeyPath = privateKeyPath;
            this.encryptionPassword = encryptionPassword;
            this.decryptionPassword = decryptionPassword;
        }
    
        public ScriptDom.CreateCertificateStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateCertificateStatement();
            ret.CertificateSource = (ScriptDom.EncryptionSource)certificateSource.ToMutable();
            ret.CertificateOptions.AddRange(certificateOptions.SelectList(c => (ScriptDom.CertificateOption)c.ToMutable()));
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            if (!(certificateSource is null)) {
                h = h * 23 + certificateSource.GetHashCode();
            }
            h = h * 23 + certificateOptions.GetHashCode();
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
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
            return Equals(obj as CreateCertificateStatement);
        } 
        
        public bool Equals(CreateCertificateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<EncryptionSource>.Default.Equals(other.CertificateSource, certificateSource)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CertificateOption>>.Default.Equals(other.CertificateOptions, certificateOptions)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
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
        
        public static bool operator ==(CreateCertificateStatement left, CreateCertificateStatement right) {
            return EqualityComparer<CreateCertificateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateCertificateStatement left, CreateCertificateStatement right) {
            return !(left == right);
        }
    
        public static CreateCertificateStatement FromMutable(ScriptDom.CreateCertificateStatement fragment) {
            return (CreateCertificateStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
