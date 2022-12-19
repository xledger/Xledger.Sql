using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AuditOption : TSqlFragment {
        protected ScriptDom.AuditOptionKind optionKind;
    
        public ScriptDom.AuditOptionKind OptionKind => optionKind;
    
        public static AuditOption FromMutable(ScriptDom.AuditOption fragment) => (AuditOption)TSqlFragment.FromMutable(fragment);
    
    }

}
