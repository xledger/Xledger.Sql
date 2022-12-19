using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterRoleAction : TSqlFragment {
        public static AlterRoleAction FromMutable(ScriptDom.AlterRoleAction fragment) => (AlterRoleAction)TSqlFragment.FromMutable(fragment);
    
    }

}
