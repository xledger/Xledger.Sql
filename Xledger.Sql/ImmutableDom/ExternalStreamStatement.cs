using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalStreamStatement : TSqlStatement {
        protected Identifier name;
        protected Literal location;
        protected Literal inputOptions;
        protected Literal outputOptions;
        protected IReadOnlyList<ExternalStreamOption> externalStreamOptions;
    
        public Identifier Name => name;
        public Literal Location => location;
        public Literal InputOptions => inputOptions;
        public Literal OutputOptions => outputOptions;
        public IReadOnlyList<ExternalStreamOption> ExternalStreamOptions => externalStreamOptions;
    
        public static ExternalStreamStatement FromMutable(ScriptDom.ExternalStreamStatement fragment) {
            return (ExternalStreamStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
