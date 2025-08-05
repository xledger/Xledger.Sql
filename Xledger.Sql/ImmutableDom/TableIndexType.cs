using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableIndexType : TSqlFragment {
        public static TableIndexType FromMutable(ScriptDom.TableIndexType fragment) => (TableIndexType)TSqlFragment.FromMutable(fragment);
    
    }

}
