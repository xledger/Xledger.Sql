using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BooleanExpression : TSqlFragment {
        public static BooleanExpression FromMutable(ScriptDom.BooleanExpression fragment) => (BooleanExpression)TSqlFragment.FromMutable(fragment);
    
    }

}
