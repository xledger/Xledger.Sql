using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FunctionStatementBody : ProcedureStatementBodyBase {
        protected SchemaObjectName name;
        protected FunctionReturnType returnType;
        protected IReadOnlyList<FunctionOption> options;
        protected OrderBulkInsertOption orderHint;
    
        public SchemaObjectName Name => name;
        public FunctionReturnType ReturnType => returnType;
        public IReadOnlyList<FunctionOption> Options => options;
        public OrderBulkInsertOption OrderHint => orderHint;
    
        public static FunctionStatementBody FromMutable(ScriptDom.FunctionStatementBody fragment) {
            return (FunctionStatementBody)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
