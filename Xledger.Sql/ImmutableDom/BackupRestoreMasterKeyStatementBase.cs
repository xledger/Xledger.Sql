using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BackupRestoreMasterKeyStatementBase : TSqlStatement {
        protected Literal file;
        protected Literal password;
    
        public Literal File => file;
        public Literal Password => password;
    
        public static BackupRestoreMasterKeyStatementBase FromMutable(ScriptDom.BackupRestoreMasterKeyStatementBase fragment) => (BackupRestoreMasterKeyStatementBase)TSqlFragment.FromMutable(fragment);
    
    }

}
