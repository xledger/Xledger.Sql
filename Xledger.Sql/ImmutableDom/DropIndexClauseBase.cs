using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DropIndexClauseBase : TSqlFragment {
        public static DropIndexClauseBase FromMutable(ScriptDom.DropIndexClauseBase fragment) => (DropIndexClauseBase)TSqlFragment.FromMutable(fragment);
    
    }

}
