using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalTableOption : TSqlFragment {
        protected ScriptDom.ExternalTableOptionKind optionKind;
    
        public ScriptDom.ExternalTableOptionKind OptionKind => optionKind;
    
        public static ExternalTableOption FromMutable(ScriptDom.ExternalTableOption fragment) => (ExternalTableOption)TSqlFragment.FromMutable(fragment);
    
    }

}
