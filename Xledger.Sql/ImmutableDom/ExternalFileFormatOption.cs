using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalFileFormatOption : TSqlFragment {
        protected ScriptDom.ExternalFileFormatOptionKind optionKind;
    
        public ScriptDom.ExternalFileFormatOptionKind OptionKind => optionKind;
    
    }

}
