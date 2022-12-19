using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ServerAuditStatement : TSqlStatement {
        protected Identifier auditName;
        protected AuditTarget auditTarget;
        protected IReadOnlyList<AuditOption> options;
        protected BooleanExpression predicateExpression;
    
        public Identifier AuditName => auditName;
        public AuditTarget AuditTarget => auditTarget;
        public IReadOnlyList<AuditOption> Options => options;
        public BooleanExpression PredicateExpression => predicateExpression;
    
        public static ServerAuditStatement FromMutable(ScriptDom.ServerAuditStatement fragment) => (ServerAuditStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
