using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class MergeAction : TSqlFragment {
        public static MergeAction FromMutable(ScriptDom.MergeAction fragment) {
            return (MergeAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
