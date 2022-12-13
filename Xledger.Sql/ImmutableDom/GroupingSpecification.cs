using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class GroupingSpecification : TSqlFragment {
        public static GroupingSpecification FromMutable(ScriptDom.GroupingSpecification fragment) {
            return (GroupingSpecification)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
