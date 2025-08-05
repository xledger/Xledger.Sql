using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SetCommand : TSqlFragment {
        public static SetCommand FromMutable(ScriptDom.SetCommand fragment) => (SetCommand)TSqlFragment.FromMutable(fragment);
    
    }

}
