using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ViewDistributionPolicy : TSqlFragment {
        public static ViewDistributionPolicy FromMutable(ScriptDom.ViewDistributionPolicy fragment) {
            return (ViewDistributionPolicy)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
