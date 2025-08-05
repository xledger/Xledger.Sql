using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TSqlStatement : TSqlFragment {
        public static TSqlStatement FromMutable(ScriptDom.TSqlStatement fragment) => (TSqlStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
