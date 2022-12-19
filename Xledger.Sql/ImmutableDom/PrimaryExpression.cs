using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class PrimaryExpression : ScalarExpression {
        protected Identifier collation;
    
        public Identifier Collation => collation;
    
        public static PrimaryExpression FromMutable(ScriptDom.PrimaryExpression fragment) => (PrimaryExpression)TSqlFragment.FromMutable(fragment);
    
    }

}
