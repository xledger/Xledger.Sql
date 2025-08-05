using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterEndpointStatement : AlterCreateEndpointStatementBase, IEquatable<AlterEndpointStatement> {
        public AlterEndpointStatement(Identifier name = null, ScriptDom.EndpointState state = ScriptDom.EndpointState.NotSpecified, EndpointAffinity affinity = null, ScriptDom.EndpointProtocol protocol = ScriptDom.EndpointProtocol.None, IReadOnlyList<EndpointProtocolOption> protocolOptions = null, ScriptDom.EndpointType endpointType = ScriptDom.EndpointType.NotSpecified, IReadOnlyList<PayloadOption> payloadOptions = null) {
            this.name = name;
            this.state = state;
            this.affinity = affinity;
            this.protocol = protocol;
            this.protocolOptions = protocolOptions.ToImmArray<EndpointProtocolOption>();
            this.endpointType = endpointType;
            this.payloadOptions = payloadOptions.ToImmArray<PayloadOption>();
        }
    
        public ScriptDom.AlterEndpointStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterEndpointStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.State = state;
            ret.Affinity = (ScriptDom.EndpointAffinity)affinity?.ToMutable();
            ret.Protocol = protocol;
            ret.ProtocolOptions.AddRange(protocolOptions.Select(c => (ScriptDom.EndpointProtocolOption)c?.ToMutable()));
            ret.EndpointType = endpointType;
            ret.PayloadOptions.AddRange(payloadOptions.Select(c => (ScriptDom.PayloadOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
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
            return Equals(obj as AlterEndpointStatement);
        } 
        
        public bool Equals(AlterEndpointStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(AlterEndpointStatement left, AlterEndpointStatement right) {
            return EqualityComparer<AlterEndpointStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterEndpointStatement left, AlterEndpointStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterEndpointStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.state, othr.state);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.affinity, othr.affinity);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.protocol, othr.protocol);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.protocolOptions, othr.protocolOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.endpointType, othr.endpointType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.payloadOptions, othr.payloadOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterEndpointStatement left, AlterEndpointStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterEndpointStatement left, AlterEndpointStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterEndpointStatement left, AlterEndpointStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterEndpointStatement left, AlterEndpointStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterEndpointStatement FromMutable(ScriptDom.AlterEndpointStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterEndpointStatement)) { throw new NotImplementedException("Unexpected subtype of AlterEndpointStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterEndpointStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                state: fragment.State,
                affinity: ImmutableDom.EndpointAffinity.FromMutable(fragment.Affinity),
                protocol: fragment.Protocol,
                protocolOptions: fragment.ProtocolOptions.ToImmArray(ImmutableDom.EndpointProtocolOption.FromMutable),
                endpointType: fragment.EndpointType,
                payloadOptions: fragment.PayloadOptions.ToImmArray(ImmutableDom.PayloadOption.FromMutable)
            );
        }
    
    }

}
