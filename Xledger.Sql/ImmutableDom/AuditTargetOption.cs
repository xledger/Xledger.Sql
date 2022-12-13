using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AuditTargetOption : TSqlFragment {
        protected ScriptDom.AuditTargetOptionKind optionKind;
    
        public ScriptDom.AuditTargetOptionKind OptionKind => optionKind;
    
        public static AuditTargetOption FromMutable(ScriptDom.AuditTargetOption fragment) {
            return (AuditTargetOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
