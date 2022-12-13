using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class QueueStatement : TSqlStatement {
        protected SchemaObjectName name;
        protected IReadOnlyList<QueueOption> queueOptions;
    
        public SchemaObjectName Name => name;
        public IReadOnlyList<QueueOption> QueueOptions => queueOptions;
    
        public static QueueStatement FromMutable(ScriptDom.QueueStatement fragment) {
            return (QueueStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
