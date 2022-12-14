using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class EventTypeGroupContainer : TSqlFragment {
        public static EventTypeGroupContainer FromMutable(ScriptDom.EventTypeGroupContainer fragment) => (EventTypeGroupContainer)TSqlFragment.FromMutable(fragment);
    
    }

}
