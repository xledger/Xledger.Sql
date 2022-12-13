using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SymmetricKeyStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<CryptoMechanism> encryptingMechanisms;
    
        public Identifier Name => name;
        public IReadOnlyList<CryptoMechanism> EncryptingMechanisms => encryptingMechanisms;
    
        public static SymmetricKeyStatement FromMutable(ScriptDom.SymmetricKeyStatement fragment) {
            return (SymmetricKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
