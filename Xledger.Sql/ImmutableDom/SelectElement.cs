using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SelectElement : TSqlFragment {
        public static SelectElement FromMutable(ScriptDom.SelectElement fragment) {
            return (SelectElement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
