using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class WorkloadGroupParameter : TSqlFragment {
        protected ScriptDom.WorkloadGroupParameterType parameterType;
    
        public ScriptDom.WorkloadGroupParameterType ParameterType => parameterType;
    
        public static WorkloadGroupParameter FromMutable(ScriptDom.WorkloadGroupParameter fragment) => (WorkloadGroupParameter)TSqlFragment.FromMutable(fragment);
    
    }

}
