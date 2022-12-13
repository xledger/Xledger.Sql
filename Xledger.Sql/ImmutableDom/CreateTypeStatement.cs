using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CreateTypeStatement : TSqlStatement {
        protected SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public static CreateTypeStatement FromMutable(ScriptDom.CreateTypeStatement fragment) {
            return (CreateTypeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
