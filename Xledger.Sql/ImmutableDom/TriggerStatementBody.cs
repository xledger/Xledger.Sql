using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TriggerStatementBody : TSqlStatement {
        protected SchemaObjectName name;
        protected TriggerObject triggerObject;
        protected IReadOnlyList<TriggerOption> options;
        protected ScriptDom.TriggerType triggerType;
        protected IReadOnlyList<TriggerAction> triggerActions;
        protected bool withAppend;
        protected bool isNotForReplication;
        protected StatementList statementList;
        protected MethodSpecifier methodSpecifier;
    
        public SchemaObjectName Name => name;
        public TriggerObject TriggerObject => triggerObject;
        public IReadOnlyList<TriggerOption> Options => options;
        public ScriptDom.TriggerType TriggerType => triggerType;
        public IReadOnlyList<TriggerAction> TriggerActions => triggerActions;
        public bool WithAppend => withAppend;
        public bool IsNotForReplication => isNotForReplication;
        public StatementList StatementList => statementList;
        public MethodSpecifier MethodSpecifier => methodSpecifier;
    
        public static TriggerStatementBody FromMutable(ScriptDom.TriggerStatementBody fragment) => (TriggerStatementBody)TSqlFragment.FromMutable(fragment);
    
    }

}
