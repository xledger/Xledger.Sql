using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalLanguageStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<ExternalLanguageFileOption> externalLanguageFiles;
    
        public Identifier Name => name;
        public IReadOnlyList<ExternalLanguageFileOption> ExternalLanguageFiles => externalLanguageFiles;
    
    }

}
