using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ValueExpression : PrimaryExpression {
        public static ValueExpression FromMutable(ScriptDom.ValueExpression fragment) => (ValueExpression)TSqlFragment.FromMutable(fragment);
    
    }

}
