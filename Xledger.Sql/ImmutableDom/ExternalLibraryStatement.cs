using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalLibraryStatement : TSqlStatement {
        protected Identifier name;
        protected StringLiteral language;
        protected IReadOnlyList<ExternalLibraryFileOption> externalLibraryFiles;
    
        public Identifier Name => name;
        public StringLiteral Language => language;
        public IReadOnlyList<ExternalLibraryFileOption> ExternalLibraryFiles => externalLibraryFiles;
    
        public static ExternalLibraryStatement FromMutable(ScriptDom.ExternalLibraryStatement fragment) => (ExternalLibraryStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
