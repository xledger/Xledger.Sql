using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BackupRestoreMasterKeyStatementBase : TSqlStatement {
        protected Literal file;
        protected Literal password;
    
        public Literal File => file;
        public Literal Password => password;
    
    }

}
