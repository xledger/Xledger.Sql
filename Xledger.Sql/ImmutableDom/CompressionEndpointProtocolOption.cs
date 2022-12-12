using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CompressionEndpointProtocolOption : EndpointProtocolOption, IEquatable<CompressionEndpointProtocolOption> {
        protected bool isEnabled = false;
    
        public bool IsEnabled => isEnabled;
    
        public CompressionEndpointProtocolOption(bool isEnabled = false, ScriptDom.EndpointProtocolOptions kind = ScriptDom.EndpointProtocolOptions.None) {
            this.isEnabled = isEnabled;
            this.kind = kind;
        }
    
        public ScriptDom.CompressionEndpointProtocolOption ToMutableConcrete() {
            var ret = new ScriptDom.CompressionEndpointProtocolOption();
            ret.IsEnabled = isEnabled;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isEnabled.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CompressionEndpointProtocolOption);
        } 
        
        public bool Equals(CompressionEndpointProtocolOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsEnabled, isEnabled)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocolOptions>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CompressionEndpointProtocolOption left, CompressionEndpointProtocolOption right) {
            return EqualityComparer<CompressionEndpointProtocolOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CompressionEndpointProtocolOption left, CompressionEndpointProtocolOption right) {
            return !(left == right);
        }
    
    }

}
