using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PortsEndpointProtocolOption : EndpointProtocolOption, IEquatable<PortsEndpointProtocolOption> {
        ScriptDom.PortTypes portTypes = ScriptDom.PortTypes.None;
    
        public ScriptDom.PortTypes PortTypes => portTypes;
    
        public PortsEndpointProtocolOption(ScriptDom.PortTypes portTypes = ScriptDom.PortTypes.None, ScriptDom.EndpointProtocolOptions kind = ScriptDom.EndpointProtocolOptions.None) {
            this.portTypes = portTypes;
            this.kind = kind;
        }
    
        public ScriptDom.PortsEndpointProtocolOption ToMutableConcrete() {
            var ret = new ScriptDom.PortsEndpointProtocolOption();
            ret.PortTypes = portTypes;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + portTypes.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PortsEndpointProtocolOption);
        } 
        
        public bool Equals(PortsEndpointProtocolOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PortTypes>.Default.Equals(other.PortTypes, portTypes)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocolOptions>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PortsEndpointProtocolOption left, PortsEndpointProtocolOption right) {
            return EqualityComparer<PortsEndpointProtocolOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PortsEndpointProtocolOption left, PortsEndpointProtocolOption right) {
            return !(left == right);
        }
    
    }

}
