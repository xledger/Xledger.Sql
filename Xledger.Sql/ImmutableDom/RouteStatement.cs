using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RouteStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<RouteOption> routeOptions;
    
        public Identifier Name => name;
        public IReadOnlyList<RouteOption> RouteOptions => routeOptions;
    
        public static RouteStatement FromMutable(ScriptDom.RouteStatement fragment) {
            return (RouteStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
