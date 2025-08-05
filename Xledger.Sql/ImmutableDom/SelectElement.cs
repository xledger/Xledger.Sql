using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SelectElement : TSqlFragment {
        public static SelectElement FromMutable(ScriptDom.SelectElement fragment) => (SelectElement)TSqlFragment.FromMutable(fragment);
    
    }

}
