using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableSwitchOption : TSqlFragment {
        protected ScriptDom.TableSwitchOptionKind optionKind;
    
        public ScriptDom.TableSwitchOptionKind OptionKind => optionKind;
    
        public static TableSwitchOption FromMutable(ScriptDom.TableSwitchOption fragment) => (TableSwitchOption)TSqlFragment.FromMutable(fragment);
    
    }

}
