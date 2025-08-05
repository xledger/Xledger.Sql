using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class IndexOption : TSqlFragment {
        protected ScriptDom.IndexOptionKind optionKind;
    
        public ScriptDom.IndexOptionKind OptionKind => optionKind;
    
        public static IndexOption FromMutable(ScriptDom.IndexOption fragment) => (IndexOption)TSqlFragment.FromMutable(fragment);
    
    }

}
