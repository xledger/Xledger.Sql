using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AuditSpecificationStatement : TSqlStatement {
        protected ScriptDom.OptionState auditState;
        protected IReadOnlyList<AuditSpecificationPart> parts;
        protected Identifier specificationName;
        protected Identifier auditName;
    
        public ScriptDom.OptionState AuditState => auditState;
        public IReadOnlyList<AuditSpecificationPart> Parts => parts;
        public Identifier SpecificationName => specificationName;
        public Identifier AuditName => auditName;
    
        public static AuditSpecificationStatement FromMutable(ScriptDom.AuditSpecificationStatement fragment) => (AuditSpecificationStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
