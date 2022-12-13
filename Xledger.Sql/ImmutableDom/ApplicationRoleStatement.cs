using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ApplicationRoleStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<ApplicationRoleOption> applicationRoleOptions;
    
        public Identifier Name => name;
        public IReadOnlyList<ApplicationRoleOption> ApplicationRoleOptions => applicationRoleOptions;
    
        public static ApplicationRoleStatement FromMutable(ScriptDom.ApplicationRoleStatement fragment) {
            return (ApplicationRoleStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
