using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class WorkloadClassifierStatement : TSqlStatement {
        protected Identifier classifierName;
        protected IReadOnlyList<WorkloadClassifierOption> options;
    
        public Identifier ClassifierName => classifierName;
        public IReadOnlyList<WorkloadClassifierOption> Options => options;
    
        public static WorkloadClassifierStatement FromMutable(ScriptDom.WorkloadClassifierStatement fragment) => (WorkloadClassifierStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
