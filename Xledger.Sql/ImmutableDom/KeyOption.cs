using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class KeyOption : TSqlFragment {
        protected ScriptDom.KeyOptionKind optionKind;
    
        public ScriptDom.KeyOptionKind OptionKind => optionKind;
    
        public static KeyOption FromMutable(ScriptDom.KeyOption fragment) => (KeyOption)TSqlFragment.FromMutable(fragment);
    
    }

}
