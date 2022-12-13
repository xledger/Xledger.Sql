using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class PartitionSpecifications : TSqlFragment {
        public static PartitionSpecifications FromMutable(ScriptDom.PartitionSpecifications fragment) {
            return (PartitionSpecifications)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
