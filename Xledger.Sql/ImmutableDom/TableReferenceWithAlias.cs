using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableReferenceWithAlias : TableReference {
        protected Identifier alias;
        protected bool forPath;
    
        public Identifier Alias => alias;
        public bool ForPath => forPath;
    
        public static TableReferenceWithAlias FromMutable(ScriptDom.TableReferenceWithAlias fragment) => (TableReferenceWithAlias)TSqlFragment.FromMutable(fragment);
    
    }

}
