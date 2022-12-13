using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class QueryStoreOption : TSqlFragment {
        protected ScriptDom.QueryStoreOptionKind optionKind;
    
        public ScriptDom.QueryStoreOptionKind OptionKind => optionKind;
    
        public static QueryStoreOption FromMutable(ScriptDom.QueryStoreOption fragment) {
            return (QueryStoreOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
