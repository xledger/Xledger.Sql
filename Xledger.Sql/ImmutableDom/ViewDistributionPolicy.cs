using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ViewDistributionPolicy : TSqlFragment {
        public static ViewDistributionPolicy FromMutable(ScriptDom.ViewDistributionPolicy fragment) => (ViewDistributionPolicy)TSqlFragment.FromMutable(fragment);
    
    }

}
