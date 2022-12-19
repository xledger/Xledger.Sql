using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RoleStatement : TSqlStatement {
        protected Identifier name;
    
        public Identifier Name => name;
    
        public static RoleStatement FromMutable(ScriptDom.RoleStatement fragment) => (RoleStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
