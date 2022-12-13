using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CertificateStatementBase : TSqlStatement {
        protected Identifier name;
        protected ScriptDom.OptionState activeForBeginDialog;
        protected Literal privateKeyPath;
        protected Literal encryptionPassword;
        protected Literal decryptionPassword;
    
        public Identifier Name => name;
        public ScriptDom.OptionState ActiveForBeginDialog => activeForBeginDialog;
        public Literal PrivateKeyPath => privateKeyPath;
        public Literal EncryptionPassword => encryptionPassword;
        public Literal DecryptionPassword => decryptionPassword;
    
        public static CertificateStatementBase FromMutable(ScriptDom.CertificateStatementBase fragment) {
            return (CertificateStatementBase)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
