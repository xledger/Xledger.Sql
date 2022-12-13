using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterDatabaseScopedConfigurationStatement : TSqlStatement {
        protected bool secondary;
    
        public bool Secondary => secondary;
    
        public static AlterDatabaseScopedConfigurationStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationStatement fragment) {
            return (AlterDatabaseScopedConfigurationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
