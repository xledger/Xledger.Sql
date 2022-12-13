using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateEndpointStatement : AlterCreateEndpointStatementBase, IEquatable<CreateEndpointStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateEndpointStatement(Identifier owner = null, Identifier name = null, ScriptDom.EndpointState state = ScriptDom.EndpointState.NotSpecified, EndpointAffinity affinity = null, ScriptDom.EndpointProtocol protocol = ScriptDom.EndpointProtocol.None, IReadOnlyList<EndpointProtocolOption> protocolOptions = null, ScriptDom.EndpointType endpointType = ScriptDom.EndpointType.NotSpecified, IReadOnlyList<PayloadOption> payloadOptions = null) {
            this.owner = owner;
            this.name = name;
            this.state = state;
            this.affinity = affinity;
            this.protocol = protocol;
            this.protocolOptions = protocolOptions is null ? ImmList<EndpointProtocolOption>.Empty : ImmList<EndpointProtocolOption>.FromList(protocolOptions);
            this.endpointType = endpointType;
            this.payloadOptions = payloadOptions is null ? ImmList<PayloadOption>.Empty : ImmList<PayloadOption>.FromList(payloadOptions);
        }
    
        public ScriptDom.CreateEndpointStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateEndpointStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.State = state;
            ret.Affinity = (ScriptDom.EndpointAffinity)affinity.ToMutable();
            ret.Protocol = protocol;
            ret.ProtocolOptions.AddRange(protocolOptions.SelectList(c => (ScriptDom.EndpointProtocolOption)c.ToMutable()));
            ret.EndpointType = endpointType;
            ret.PayloadOptions.AddRange(payloadOptions.SelectList(c => (ScriptDom.PayloadOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + state.GetHashCode();
            if (!(affinity is null)) {
                h = h * 23 + affinity.GetHashCode();
            }
            h = h * 23 + protocol.GetHashCode();
            h = h * 23 + protocolOptions.GetHashCode();
            h = h * 23 + endpointType.GetHashCode();
            h = h * 23 + payloadOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateEndpointStatement);
        } 
        
        public bool Equals(CreateEndpointStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointState>.Default.Equals(other.State, state)) {
                return false;
            }
            if (!EqualityComparer<EndpointAffinity>.Default.Equals(other.Affinity, affinity)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocol>.Default.Equals(other.Protocol, protocol)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EndpointProtocolOption>>.Default.Equals(other.ProtocolOptions, protocolOptions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointType>.Default.Equals(other.EndpointType, endpointType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PayloadOption>>.Default.Equals(other.PayloadOptions, payloadOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateEndpointStatement left, CreateEndpointStatement right) {
            return EqualityComparer<CreateEndpointStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateEndpointStatement left, CreateEndpointStatement right) {
            return !(left == right);
        }
    
        public static CreateEndpointStatement FromMutable(ScriptDom.CreateEndpointStatement fragment) {
            return (CreateEndpointStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
