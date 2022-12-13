using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuthenticationEndpointProtocolOption : EndpointProtocolOption, IEquatable<AuthenticationEndpointProtocolOption> {
        protected ScriptDom.AuthenticationTypes authenticationTypes = ScriptDom.AuthenticationTypes.None;
    
        public ScriptDom.AuthenticationTypes AuthenticationTypes => authenticationTypes;
    
        public AuthenticationEndpointProtocolOption(ScriptDom.AuthenticationTypes authenticationTypes = ScriptDom.AuthenticationTypes.None, ScriptDom.EndpointProtocolOptions kind = ScriptDom.EndpointProtocolOptions.None) {
            this.authenticationTypes = authenticationTypes;
            this.kind = kind;
        }
    
        public ScriptDom.AuthenticationEndpointProtocolOption ToMutableConcrete() {
            var ret = new ScriptDom.AuthenticationEndpointProtocolOption();
            ret.AuthenticationTypes = authenticationTypes;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + authenticationTypes.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuthenticationEndpointProtocolOption);
        } 
        
        public bool Equals(AuthenticationEndpointProtocolOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AuthenticationTypes>.Default.Equals(other.AuthenticationTypes, authenticationTypes)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocolOptions>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) {
            return EqualityComparer<AuthenticationEndpointProtocolOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) {
            return !(left == right);
        }
    
        public static AuthenticationEndpointProtocolOption FromMutable(ScriptDom.AuthenticationEndpointProtocolOption fragment) {
            return (AuthenticationEndpointProtocolOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
