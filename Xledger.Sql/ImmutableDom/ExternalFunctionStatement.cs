using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalFunctionStatement : TSqlStatement {
        protected SchemaObjectName name;
        protected IReadOnlyList<ProcedureParameter> parameters;
        protected DataTypeReference returnType;
        protected SchemaObjectName externalName;
    
        public SchemaObjectName Name => name;
        public IReadOnlyList<ProcedureParameter> Parameters => parameters;
        public DataTypeReference ReturnType => returnType;
        public SchemaObjectName ExternalName => externalName;
    
        public static ExternalFunctionStatement FromMutable(ScriptDom.ExternalFunctionStatement fragment) => (ExternalFunctionStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
