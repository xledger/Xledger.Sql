using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterDatabaseStatement : TSqlStatement {
        protected Identifier databaseName;
        protected bool useCurrent;
    
        public Identifier DatabaseName => databaseName;
        public bool UseCurrent => useCurrent;
    
        public static AlterDatabaseStatement FromMutable(ScriptDom.AlterDatabaseStatement fragment) {
            return (AlterDatabaseStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
