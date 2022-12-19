using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class CursorStatement : TSqlStatement {
        protected CursorId cursor;
    
        public CursorId Cursor => cursor;
    
        public static CursorStatement FromMutable(ScriptDom.CursorStatement fragment) => (CursorStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
