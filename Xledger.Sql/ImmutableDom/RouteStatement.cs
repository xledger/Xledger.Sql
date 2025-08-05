using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RouteStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<RouteOption> routeOptions;
    
        public Identifier Name => name;
        public IReadOnlyList<RouteOption> RouteOptions => routeOptions;
    
        public static RouteStatement FromMutable(ScriptDom.RouteStatement fragment) => (RouteStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
