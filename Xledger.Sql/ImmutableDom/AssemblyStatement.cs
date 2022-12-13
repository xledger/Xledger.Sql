using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AssemblyStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<ScalarExpression> parameters;
        protected IReadOnlyList<AssemblyOption> options;
    
        public Identifier Name => name;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
        public IReadOnlyList<AssemblyOption> Options => options;
    
        public static AssemblyStatement FromMutable(ScriptDom.AssemblyStatement fragment) {
            return (AssemblyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
