using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TableOption : TSqlFragment {
        protected ScriptDom.TableOptionKind optionKind;
    
        public ScriptDom.TableOptionKind OptionKind => optionKind;
    
        public static TableOption FromMutable(ScriptDom.TableOption fragment) => (TableOption)TSqlFragment.FromMutable(fragment);
    
    }

}
