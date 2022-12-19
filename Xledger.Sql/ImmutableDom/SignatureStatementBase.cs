using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SignatureStatementBase : TSqlStatement {
        protected bool isCounter;
        protected ScriptDom.SignableElementKind elementKind;
        protected SchemaObjectName element;
        protected IReadOnlyList<CryptoMechanism> cryptos;
    
        public bool IsCounter => isCounter;
        public ScriptDom.SignableElementKind ElementKind => elementKind;
        public SchemaObjectName Element => element;
        public IReadOnlyList<CryptoMechanism> Cryptos => cryptos;
    
        public static SignatureStatementBase FromMutable(ScriptDom.SignatureStatementBase fragment) => (SignatureStatementBase)TSqlFragment.FromMutable(fragment);
    
    }

}
