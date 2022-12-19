using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RemoteServiceBindingOption : TSqlFragment {
        protected ScriptDom.RemoteServiceBindingOptionKind optionKind;
    
        public ScriptDom.RemoteServiceBindingOptionKind OptionKind => optionKind;
    
        public static RemoteServiceBindingOption FromMutable(ScriptDom.RemoteServiceBindingOption fragment) => (RemoteServiceBindingOption)TSqlFragment.FromMutable(fragment);
    
    }

}
