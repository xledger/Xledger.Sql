using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ViewStatementBody : TSqlStatement {
        protected SchemaObjectName schemaObjectName;
        protected IReadOnlyList<Identifier> columns;
        protected IReadOnlyList<ViewOption> viewOptions;
        protected SelectStatement selectStatement;
        protected bool withCheckOption;
        protected bool isMaterialized;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public IReadOnlyList<Identifier> Columns => columns;
        public IReadOnlyList<ViewOption> ViewOptions => viewOptions;
        public SelectStatement SelectStatement => selectStatement;
        public bool WithCheckOption => withCheckOption;
        public bool IsMaterialized => isMaterialized;
    
        public static ViewStatementBody FromMutable(ScriptDom.ViewStatementBody fragment) => (ViewStatementBody)TSqlFragment.FromMutable(fragment);
    
    }

}
