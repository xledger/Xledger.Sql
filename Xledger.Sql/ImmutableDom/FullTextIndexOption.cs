using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FullTextIndexOption : TSqlFragment {
        protected ScriptDom.FullTextIndexOptionKind optionKind;
    
        public ScriptDom.FullTextIndexOptionKind OptionKind => optionKind;
    
        public static FullTextIndexOption FromMutable(ScriptDom.FullTextIndexOption fragment) => (FullTextIndexOption)TSqlFragment.FromMutable(fragment);
    
    }

}
