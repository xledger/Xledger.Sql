using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class Literal : ValueExpression {
        protected string @value;
    
        public string Value => @value;
    
        public static Literal FromMutable(ScriptDom.Literal fragment) {
            return (Literal)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
