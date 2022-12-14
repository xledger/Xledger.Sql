using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableReferenceWithAliasAndColumns : TableReferenceWithAlias {
        protected IReadOnlyList<Identifier> columns;
    
        public IReadOnlyList<Identifier> Columns => columns;
    
        public static TableReferenceWithAliasAndColumns FromMutable(ScriptDom.TableReferenceWithAliasAndColumns fragment) => (TableReferenceWithAliasAndColumns)TSqlFragment.FromMutable(fragment);
    
    }

}
