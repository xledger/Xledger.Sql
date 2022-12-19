using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CredentialStatement : TSqlStatement {
        protected Identifier name;
        protected Literal identity;
        protected Literal secret;
        protected bool isDatabaseScoped;
    
        public Identifier Name => name;
        public Literal Identity => identity;
        public Literal Secret => secret;
        public bool IsDatabaseScoped => isDatabaseScoped;
    
        public static CredentialStatement FromMutable(ScriptDom.CredentialStatement fragment) => (CredentialStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
