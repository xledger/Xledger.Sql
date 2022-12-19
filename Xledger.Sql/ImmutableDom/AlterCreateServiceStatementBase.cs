using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterCreateServiceStatementBase : TSqlStatement {
        protected Identifier name;
        protected SchemaObjectName queueName;
        protected IReadOnlyList<ServiceContract> serviceContracts;
    
        public Identifier Name => name;
        public SchemaObjectName QueueName => queueName;
        public IReadOnlyList<ServiceContract> ServiceContracts => serviceContracts;
    
        public static AlterCreateServiceStatementBase FromMutable(ScriptDom.AlterCreateServiceStatementBase fragment) => (AlterCreateServiceStatementBase)TSqlFragment.FromMutable(fragment);
    
    }

}
