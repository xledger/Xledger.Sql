using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SecurityStatementBody80 : TSqlStatement {
        protected SecurityElement80 securityElement80;
        protected SecurityUserClause80 securityUserClause80;
    
        public SecurityElement80 SecurityElement80 => securityElement80;
        public SecurityUserClause80 SecurityUserClause80 => securityUserClause80;
    
    }

}
