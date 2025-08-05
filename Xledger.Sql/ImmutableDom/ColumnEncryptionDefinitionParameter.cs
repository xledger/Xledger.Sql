using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ColumnEncryptionDefinitionParameter : TSqlFragment {
        protected ScriptDom.ColumnEncryptionDefinitionParameterKind parameterKind;
    
        public ScriptDom.ColumnEncryptionDefinitionParameterKind ParameterKind => parameterKind;
    
        public static ColumnEncryptionDefinitionParameter FromMutable(ScriptDom.ColumnEncryptionDefinitionParameter fragment) => (ColumnEncryptionDefinitionParameter)TSqlFragment.FromMutable(fragment);
    
    }

}
