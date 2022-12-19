using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class MasterKeyStatement : TSqlStatement {
        protected Literal password;
    
        public Literal Password => password;
    
        public static MasterKeyStatement FromMutable(ScriptDom.MasterKeyStatement fragment) => (MasterKeyStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
