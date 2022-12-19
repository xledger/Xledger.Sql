using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class JoinTableReference : TableReference {
        protected TableReference firstTableReference;
        protected TableReference secondTableReference;
    
        public TableReference FirstTableReference => firstTableReference;
        public TableReference SecondTableReference => secondTableReference;
    
        public static JoinTableReference FromMutable(ScriptDom.JoinTableReference fragment) => (JoinTableReference)TSqlFragment.FromMutable(fragment);
    
    }

}
