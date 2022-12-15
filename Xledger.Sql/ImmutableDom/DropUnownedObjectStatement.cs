using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DropUnownedObjectStatement : TSqlStatement {
        protected Identifier name;
        protected bool isIfExists;
    
        public Identifier Name => name;
        public bool IsIfExists => isIfExists;
    
    }

}
