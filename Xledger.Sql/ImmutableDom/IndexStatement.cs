using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class IndexStatement : TSqlStatement {
        protected Identifier name;
        protected SchemaObjectName onName;
        protected IReadOnlyList<IndexOption> indexOptions;
    
        public Identifier Name => name;
        public SchemaObjectName OnName => onName;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
    
    }

}
