using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SearchPropertyListAction : TSqlFragment {
        public static SearchPropertyListAction FromMutable(ScriptDom.SearchPropertyListAction fragment) => (SearchPropertyListAction)TSqlFragment.FromMutable(fragment);
    
    }

}
