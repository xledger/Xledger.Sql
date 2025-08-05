using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalDataSourceStatement : TSqlStatement {
        protected Identifier name;
        protected ScriptDom.ExternalDataSourceType dataSourceType;
        protected Literal location;
        protected ScriptDom.ExternalDataSourcePushdownOption? pushdownOption;
        protected IReadOnlyList<ExternalDataSourceOption> externalDataSourceOptions;
    
        public Identifier Name => name;
        public ScriptDom.ExternalDataSourceType DataSourceType => dataSourceType;
        public Literal Location => location;
        public ScriptDom.ExternalDataSourcePushdownOption? PushdownOption => pushdownOption;
        public IReadOnlyList<ExternalDataSourceOption> ExternalDataSourceOptions => externalDataSourceOptions;
    
        public static ExternalDataSourceStatement FromMutable(ScriptDom.ExternalDataSourceStatement fragment) => (ExternalDataSourceStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
