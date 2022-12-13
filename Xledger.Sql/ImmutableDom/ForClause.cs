using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ForClause : TSqlFragment {
        public static ForClause FromMutable(ScriptDom.ForClause fragment) {
            return (ForClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
