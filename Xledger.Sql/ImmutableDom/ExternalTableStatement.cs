using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalTableStatement : TSqlStatement {
        protected SchemaObjectName schemaObjectName;
        protected IReadOnlyList<ExternalTableColumnDefinition> columnDefinitions;
        protected Identifier dataSource;
        protected IReadOnlyList<ExternalTableOption> externalTableOptions;
        protected SelectStatement selectStatement;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public IReadOnlyList<ExternalTableColumnDefinition> ColumnDefinitions => columnDefinitions;
        public Identifier DataSource => dataSource;
        public IReadOnlyList<ExternalTableOption> ExternalTableOptions => externalTableOptions;
        public SelectStatement SelectStatement => selectStatement;
    
        public static ExternalTableStatement FromMutable(ScriptDom.ExternalTableStatement fragment) => (ExternalTableStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
