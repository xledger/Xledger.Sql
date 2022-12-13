using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DatabaseEncryptionKeyStatement : TSqlStatement {
        protected CryptoMechanism encryptor;
        protected ScriptDom.DatabaseEncryptionKeyAlgorithm algorithm;
    
        public CryptoMechanism Encryptor => encryptor;
        public ScriptDom.DatabaseEncryptionKeyAlgorithm Algorithm => algorithm;
    
        public static DatabaseEncryptionKeyStatement FromMutable(ScriptDom.DatabaseEncryptionKeyStatement fragment) {
            return (DatabaseEncryptionKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
