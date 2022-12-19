using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SetClause : TSqlFragment {
        public static SetClause FromMutable(ScriptDom.SetClause fragment) => (SetClause)TSqlFragment.FromMutable(fragment);
    
    }

}
