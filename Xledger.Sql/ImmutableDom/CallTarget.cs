using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CallTarget : TSqlFragment {
        public static CallTarget FromMutable(ScriptDom.CallTarget fragment) {
            return (CallTarget)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
