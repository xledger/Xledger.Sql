using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ParameterizedDataTypeReference : DataTypeReference {
        protected IReadOnlyList<Literal> parameters;
    
        public IReadOnlyList<Literal> Parameters => parameters;
    
        public static ParameterizedDataTypeReference FromMutable(ScriptDom.ParameterizedDataTypeReference fragment) {
            return (ParameterizedDataTypeReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
