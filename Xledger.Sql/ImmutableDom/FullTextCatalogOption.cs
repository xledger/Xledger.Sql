using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FullTextCatalogOption : TSqlFragment {
        protected ScriptDom.FullTextCatalogOptionKind optionKind;
    
        public ScriptDom.FullTextCatalogOptionKind OptionKind => optionKind;
    
        public static FullTextCatalogOption FromMutable(ScriptDom.FullTextCatalogOption fragment) => (FullTextCatalogOption)TSqlFragment.FromMutable(fragment);
    
    }

}
