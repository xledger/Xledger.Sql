using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExecutableEntity : TSqlFragment {
        protected IReadOnlyList<ExecuteParameter> parameters;
    
        public IReadOnlyList<ExecuteParameter> Parameters => parameters;
    
        public static ExecutableEntity FromMutable(ScriptDom.ExecutableEntity fragment) => (ExecutableEntity)TSqlFragment.FromMutable(fragment);
    
    }

}
