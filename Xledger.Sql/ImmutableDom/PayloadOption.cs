using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class PayloadOption : TSqlFragment {
        protected ScriptDom.PayloadOptionKinds kind;
    
        public ScriptDom.PayloadOptionKinds Kind => kind;
    
        public static PayloadOption FromMutable(ScriptDom.PayloadOption fragment) => (PayloadOption)TSqlFragment.FromMutable(fragment);
    
    }

}
