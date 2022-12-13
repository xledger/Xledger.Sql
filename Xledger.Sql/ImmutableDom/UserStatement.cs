using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class UserStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<PrincipalOption> userOptions;
    
        public Identifier Name => name;
        public IReadOnlyList<PrincipalOption> UserOptions => userOptions;
    
        public static UserStatement FromMutable(ScriptDom.UserStatement fragment) {
            return (UserStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
