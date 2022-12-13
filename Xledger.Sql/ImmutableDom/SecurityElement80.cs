using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SecurityElement80 : TSqlFragment {
        public static SecurityElement80 FromMutable(ScriptDom.SecurityElement80 fragment) {
            return (SecurityElement80)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
