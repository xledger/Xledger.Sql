using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SpatialIndexOption : TSqlFragment {
        public static SpatialIndexOption FromMutable(ScriptDom.SpatialIndexOption fragment) {
            return (SpatialIndexOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
