using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DataModificationStatement : StatementWithCtesAndXmlNamespaces {
        public static DataModificationStatement FromMutable(ScriptDom.DataModificationStatement fragment) {
            return (DataModificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
