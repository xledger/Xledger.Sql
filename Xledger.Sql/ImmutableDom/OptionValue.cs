using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class OptionValue : TSqlFragment {
        public static OptionValue FromMutable(ScriptDom.OptionValue fragment) => (OptionValue)TSqlFragment.FromMutable(fragment);
    
    }

}
