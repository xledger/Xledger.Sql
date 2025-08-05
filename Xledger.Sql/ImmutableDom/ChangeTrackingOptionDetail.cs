using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ChangeTrackingOptionDetail : TSqlFragment {
        public static ChangeTrackingOptionDetail FromMutable(ScriptDom.ChangeTrackingOptionDetail fragment) => (ChangeTrackingOptionDetail)TSqlFragment.FromMutable(fragment);
    
    }

}
