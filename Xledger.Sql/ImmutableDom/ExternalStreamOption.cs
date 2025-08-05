using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalStreamOption : TSqlFragment {
        protected ScriptDom.ExternalStreamOptionKind optionKind;
    
        public ScriptDom.ExternalStreamOptionKind OptionKind => optionKind;
    
        public static ExternalStreamOption FromMutable(ScriptDom.ExternalStreamOption fragment) => (ExternalStreamOption)TSqlFragment.FromMutable(fragment);
    
    }

}
