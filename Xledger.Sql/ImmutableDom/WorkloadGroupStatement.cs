using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class WorkloadGroupStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<WorkloadGroupParameter> workloadGroupParameters;
        protected Identifier poolName;
        protected Identifier externalPoolName;
    
        public Identifier Name => name;
        public IReadOnlyList<WorkloadGroupParameter> WorkloadGroupParameters => workloadGroupParameters;
        public Identifier PoolName => poolName;
        public Identifier ExternalPoolName => externalPoolName;
    
    }

}
