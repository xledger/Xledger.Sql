using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DataModificationStatement : StatementWithCtesAndXmlNamespaces {
        public static DataModificationStatement FromMutable(ScriptDom.DataModificationStatement fragment) => (DataModificationStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
