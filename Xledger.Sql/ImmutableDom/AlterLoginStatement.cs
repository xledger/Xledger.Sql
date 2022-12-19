using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterLoginStatement : TSqlStatement {
        protected Identifier name;
    
        public Identifier Name => name;
    
        public static AlterLoginStatement FromMutable(ScriptDom.AlterLoginStatement fragment) => (AlterLoginStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
