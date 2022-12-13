using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TextModificationStatement : TSqlStatement {
        protected bool bulk;
        protected ColumnReferenceExpression column;
        protected ValueExpression textId;
        protected Literal timestamp;
        protected bool withLog;
    
        public bool Bulk => bulk;
        public ColumnReferenceExpression Column => column;
        public ValueExpression TextId => textId;
        public Literal Timestamp => timestamp;
        public bool WithLog => withLog;
    
        public static TextModificationStatement FromMutable(ScriptDom.TextModificationStatement fragment) {
            return (TextModificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
