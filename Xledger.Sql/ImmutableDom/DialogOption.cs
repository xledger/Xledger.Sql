using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DialogOption : TSqlFragment {
        protected ScriptDom.DialogOptionKind optionKind;
    
        public ScriptDom.DialogOptionKind OptionKind => optionKind;
    
        public static DialogOption FromMutable(ScriptDom.DialogOption fragment) {
            return (DialogOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
