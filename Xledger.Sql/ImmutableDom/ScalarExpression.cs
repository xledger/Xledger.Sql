using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ScalarExpression : TSqlFragment {
        public static ScalarExpression FromMutable(ScriptDom.ScalarExpression fragment) => (ScalarExpression)TSqlFragment.FromMutable(fragment);
    
    }

}
