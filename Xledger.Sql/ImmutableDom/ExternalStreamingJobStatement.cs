using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalStreamingJobStatement : TSqlStatement {
        protected StringLiteral name;
        protected StringLiteral statement;
    
        public StringLiteral Name => name;
        public StringLiteral Statement => statement;
    
        public static ExternalStreamingJobStatement FromMutable(ScriptDom.ExternalStreamingJobStatement fragment) => (ExternalStreamingJobStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
