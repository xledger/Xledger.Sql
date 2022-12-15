using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BrokerPriorityStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<BrokerPriorityParameter> brokerPriorityParameters;
    
        public Identifier Name => name;
        public IReadOnlyList<BrokerPriorityParameter> BrokerPriorityParameters => brokerPriorityParameters;
    
    }

}
