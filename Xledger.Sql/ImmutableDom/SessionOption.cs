using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SessionOption : TSqlFragment {
        protected ScriptDom.SessionOptionKind optionKind;
    
        public ScriptDom.SessionOptionKind OptionKind => optionKind;
    
        public static SessionOption FromMutable(ScriptDom.SessionOption fragment) => (SessionOption)TSqlFragment.FromMutable(fragment);
    
    }

}
