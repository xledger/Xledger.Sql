using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ColumnEncryptionKeyStatement : TSqlStatement {
        protected Identifier name;
        protected IReadOnlyList<ColumnEncryptionKeyValue> columnEncryptionKeyValues;
    
        public Identifier Name => name;
        public IReadOnlyList<ColumnEncryptionKeyValue> ColumnEncryptionKeyValues => columnEncryptionKeyValues;
    
        public static ColumnEncryptionKeyStatement FromMutable(ScriptDom.ColumnEncryptionKeyStatement fragment) {
            return (ColumnEncryptionKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
