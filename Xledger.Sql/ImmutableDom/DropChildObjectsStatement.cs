using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DropChildObjectsStatement : TSqlStatement {
        protected IReadOnlyList<ChildObjectName> objects;
    
        public IReadOnlyList<ChildObjectName> Objects => objects;
    
        public static DropChildObjectsStatement FromMutable(ScriptDom.DropChildObjectsStatement fragment) => (DropChildObjectsStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
