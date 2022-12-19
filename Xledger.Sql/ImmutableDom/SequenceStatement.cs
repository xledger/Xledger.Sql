using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SequenceStatement : TSqlStatement {
        protected SchemaObjectName name;
        protected IReadOnlyList<SequenceOption> sequenceOptions;
    
        public SchemaObjectName Name => name;
        public IReadOnlyList<SequenceOption> SequenceOptions => sequenceOptions;
    
        public static SequenceStatement FromMutable(ScriptDom.SequenceStatement fragment) => (SequenceStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
