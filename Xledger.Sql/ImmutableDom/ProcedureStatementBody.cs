using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        protected ProcedureReference procedureReference;
        protected bool isForReplication;
        protected IReadOnlyList<ProcedureOption> options;
    
        public ProcedureReference ProcedureReference => procedureReference;
        public bool IsForReplication => isForReplication;
        public IReadOnlyList<ProcedureOption> Options => options;
    
    }

}
