using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SecurityStatement : TSqlStatement {
        protected IReadOnlyList<Permission> permissions;
        protected SecurityTargetObject securityTargetObject;
        protected IReadOnlyList<SecurityPrincipal> principals;
        protected Identifier asClause;
    
        public IReadOnlyList<Permission> Permissions => permissions;
        public SecurityTargetObject SecurityTargetObject => securityTargetObject;
        public IReadOnlyList<SecurityPrincipal> Principals => principals;
        public Identifier AsClause => asClause;
    
        public static SecurityStatement FromMutable(ScriptDom.SecurityStatement fragment) => (SecurityStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
