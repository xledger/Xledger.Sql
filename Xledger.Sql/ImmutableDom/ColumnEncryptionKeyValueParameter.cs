using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ColumnEncryptionKeyValueParameter : TSqlFragment {
        protected ScriptDom.ColumnEncryptionKeyValueParameterKind parameterKind;
    
        public ScriptDom.ColumnEncryptionKeyValueParameterKind ParameterKind => parameterKind;
    
        public static ColumnEncryptionKeyValueParameter FromMutable(ScriptDom.ColumnEncryptionKeyValueParameter fragment) => (ColumnEncryptionKeyValueParameter)TSqlFragment.FromMutable(fragment);
    
    }

}
