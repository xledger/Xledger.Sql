using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AlterCreateEndpointStatementBase : TSqlStatement {
        protected Identifier name;
        protected ScriptDom.EndpointState state;
        protected EndpointAffinity affinity;
        protected ScriptDom.EndpointProtocol protocol;
        protected IReadOnlyList<EndpointProtocolOption> protocolOptions;
        protected ScriptDom.EndpointType endpointType;
        protected IReadOnlyList<PayloadOption> payloadOptions;
    
        public Identifier Name => name;
        public ScriptDom.EndpointState State => state;
        public EndpointAffinity Affinity => affinity;
        public ScriptDom.EndpointProtocol Protocol => protocol;
        public IReadOnlyList<EndpointProtocolOption> ProtocolOptions => protocolOptions;
        public ScriptDom.EndpointType EndpointType => endpointType;
        public IReadOnlyList<PayloadOption> PayloadOptions => payloadOptions;
    
    }

}
