using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class BackupStatement : TSqlStatement {
        protected IdentifierOrValueExpression databaseName;
        protected IReadOnlyList<BackupOption> options;
        protected IReadOnlyList<MirrorToClause> mirrorToClauses;
        protected IReadOnlyList<DeviceInfo> devices;
    
        public IdentifierOrValueExpression DatabaseName => databaseName;
        public IReadOnlyList<BackupOption> Options => options;
        public IReadOnlyList<MirrorToClause> MirrorToClauses => mirrorToClauses;
        public IReadOnlyList<DeviceInfo> Devices => devices;
    
        public static BackupStatement FromMutable(ScriptDom.BackupStatement fragment) => (BackupStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
