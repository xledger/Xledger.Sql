using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class WorkloadClassifierOption : TSqlFragment {
        protected ScriptDom.WorkloadClassifierOptionType optionType;
    
        public ScriptDom.WorkloadClassifierOptionType OptionType => optionType;
    
        public static WorkloadClassifierOption FromMutable(ScriptDom.WorkloadClassifierOption fragment) => (WorkloadClassifierOption)TSqlFragment.FromMutable(fragment);
    
    }

}
