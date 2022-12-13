using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TransactionStatement : TSqlStatement {
        protected IdentifierOrValueExpression name;
    
        public IdentifierOrValueExpression Name => name;
    
        public static TransactionStatement FromMutable(ScriptDom.TransactionStatement fragment) {
            return (TransactionStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
