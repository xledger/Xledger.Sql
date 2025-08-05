using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RemoteServiceBindingStatementBase : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<RemoteServiceBindingOption> options;
    
        public Identifier Name => name;
        public IReadOnlyList<RemoteServiceBindingOption> Options => options;
    
        public static RemoteServiceBindingStatementBase FromMutable(ScriptDom.RemoteServiceBindingStatementBase fragment) => (RemoteServiceBindingStatementBase)TSqlFragment.FromMutable(fragment);
    
    }

}
