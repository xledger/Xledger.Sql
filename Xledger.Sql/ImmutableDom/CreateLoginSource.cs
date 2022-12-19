using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CreateLoginSource : TSqlFragment {
        public static CreateLoginSource FromMutable(ScriptDom.CreateLoginSource fragment) => (CreateLoginSource)TSqlFragment.FromMutable(fragment);
    
    }

}
