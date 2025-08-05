using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FullTextCatalogStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<FullTextCatalogOption> options;
    
        public Identifier Name => name;
        public IReadOnlyList<FullTextCatalogOption> Options => options;
    
        public static FullTextCatalogStatement FromMutable(ScriptDom.FullTextCatalogStatement fragment) => (FullTextCatalogStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
