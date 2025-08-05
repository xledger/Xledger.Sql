using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AtomicBlockOption : TSqlFragment {
        protected ScriptDom.AtomicBlockOptionKind optionKind;
    
        public ScriptDom.AtomicBlockOptionKind OptionKind => optionKind;
    
        public static AtomicBlockOption FromMutable(ScriptDom.AtomicBlockOption fragment) => (AtomicBlockOption)TSqlFragment.FromMutable(fragment);
    
    }

}
