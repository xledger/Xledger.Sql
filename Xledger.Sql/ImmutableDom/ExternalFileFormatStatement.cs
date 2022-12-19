using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalFileFormatStatement : TSqlStatement {
        protected Identifier name;
        protected ScriptDom.ExternalFileFormatType formatType;
        protected IReadOnlyList<ExternalFileFormatOption> externalFileFormatOptions;
    
        public Identifier Name => name;
        public ScriptDom.ExternalFileFormatType FormatType => formatType;
        public IReadOnlyList<ExternalFileFormatOption> ExternalFileFormatOptions => externalFileFormatOptions;
    
        public static ExternalFileFormatStatement FromMutable(ScriptDom.ExternalFileFormatStatement fragment) => (ExternalFileFormatStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
