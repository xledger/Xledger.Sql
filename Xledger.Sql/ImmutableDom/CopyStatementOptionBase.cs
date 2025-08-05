using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CopyStatementOptionBase : TSqlFragment {
        public static CopyStatementOptionBase FromMutable(ScriptDom.CopyStatementOptionBase fragment) => (CopyStatementOptionBase)TSqlFragment.FromMutable(fragment);
    
    }

}
