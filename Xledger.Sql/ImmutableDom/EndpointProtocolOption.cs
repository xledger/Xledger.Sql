using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class EndpointProtocolOption : TSqlFragment {
        protected ScriptDom.EndpointProtocolOptions kind;
    
        public ScriptDom.EndpointProtocolOptions Kind => kind;
    
        public static EndpointProtocolOption FromMutable(ScriptDom.EndpointProtocolOption fragment) => (EndpointProtocolOption)TSqlFragment.FromMutable(fragment);
    
    }

}
