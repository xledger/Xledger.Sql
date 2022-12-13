using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterFullTextIndexAction : TSqlFragment {
        public static AlterFullTextIndexAction FromMutable(ScriptDom.AlterFullTextIndexAction fragment) {
            return (AlterFullTextIndexAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
