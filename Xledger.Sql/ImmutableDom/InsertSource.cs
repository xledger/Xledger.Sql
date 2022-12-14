using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class InsertSource : TSqlFragment {
        public static InsertSource FromMutable(ScriptDom.InsertSource fragment) => (InsertSource)TSqlFragment.FromMutable(fragment);
    
    }

}
