using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class LowPriorityLockWaitOption : TSqlFragment {
        protected ScriptDom.LowPriorityLockWaitOptionKind optionKind;
    
        public ScriptDom.LowPriorityLockWaitOptionKind OptionKind => optionKind;
    
    }

}
