using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BulkInsertBase : TSqlStatement {
        protected SchemaObjectName to;
        protected IReadOnlyList<BulkInsertOption> options;
    
        public SchemaObjectName To => to;
        public IReadOnlyList<BulkInsertOption> Options => options;
    
    }

}
