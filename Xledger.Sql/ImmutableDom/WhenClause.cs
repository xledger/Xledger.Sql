using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class WhenClause : TSqlFragment {
        protected ScalarExpression thenExpression;
    
        public ScalarExpression ThenExpression => thenExpression;
    
        public static WhenClause FromMutable(ScriptDom.WhenClause fragment) => (WhenClause)TSqlFragment.FromMutable(fragment);
    
    }

}
