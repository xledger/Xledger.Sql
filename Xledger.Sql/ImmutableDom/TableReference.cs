using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableReference : TSqlFragment {
        public static TableReference FromMutable(ScriptDom.TableReference fragment) => (TableReference)TSqlFragment.FromMutable(fragment);
    
    }

}
