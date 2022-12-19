using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DataTypeReference : TSqlFragment {
        protected SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public static DataTypeReference FromMutable(ScriptDom.DataTypeReference fragment) => (DataTypeReference)TSqlFragment.FromMutable(fragment);
    
    }

}
