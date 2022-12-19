using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ProcedureStatementBodyBase : TSqlStatement {
        protected IReadOnlyList<ProcedureParameter> parameters;
        protected StatementList statementList;
        protected MethodSpecifier methodSpecifier;
    
        public IReadOnlyList<ProcedureParameter> Parameters => parameters;
        public StatementList StatementList => statementList;
        public MethodSpecifier MethodSpecifier => methodSpecifier;
    
        public static ProcedureStatementBodyBase FromMutable(ScriptDom.ProcedureStatementBodyBase fragment) => (ProcedureStatementBodyBase)TSqlFragment.FromMutable(fragment);
    
    }

}
