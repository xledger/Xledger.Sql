using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AvailabilityGroupStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<AvailabilityGroupOption> options;
        protected IReadOnlyList<Identifier> databases;
        protected IReadOnlyList<AvailabilityReplica> replicas;
    
        public Identifier Name => name;
        public IReadOnlyList<AvailabilityGroupOption> Options => options;
        public IReadOnlyList<Identifier> Databases => databases;
        public IReadOnlyList<AvailabilityReplica> Replicas => replicas;
    
    }

}
