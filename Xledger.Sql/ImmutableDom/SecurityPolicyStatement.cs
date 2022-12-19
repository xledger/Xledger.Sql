using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SecurityPolicyStatement : TSqlStatement {
        protected SchemaObjectName name;
        protected bool notForReplication;
        protected IReadOnlyList<SecurityPolicyOption> securityPolicyOptions;
        protected IReadOnlyList<SecurityPredicateAction> securityPredicateActions;
        protected ScriptDom.SecurityPolicyActionType actionType;
    
        public SchemaObjectName Name => name;
        public bool NotForReplication => notForReplication;
        public IReadOnlyList<SecurityPolicyOption> SecurityPolicyOptions => securityPolicyOptions;
        public IReadOnlyList<SecurityPredicateAction> SecurityPredicateActions => securityPredicateActions;
        public ScriptDom.SecurityPolicyActionType ActionType => actionType;
    
        public static SecurityPolicyStatement FromMutable(ScriptDom.SecurityPolicyStatement fragment) => (SecurityPolicyStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
