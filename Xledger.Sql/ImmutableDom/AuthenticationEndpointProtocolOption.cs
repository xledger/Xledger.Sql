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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AuthenticationEndpointProtocolOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.authenticationTypes, othr.authenticationTypes);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AuthenticationEndpointProtocolOption left, AuthenticationEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
