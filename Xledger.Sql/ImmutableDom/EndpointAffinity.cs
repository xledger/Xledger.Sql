using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EndpointAffinity : TSqlFragment, IEquatable<EndpointAffinity> {
        ScriptDom.AffinityKind kind = ScriptDom.AffinityKind.NotSpecified;
        Literal @value;
    
        public ScriptDom.AffinityKind Kind => kind;
        public Literal Value => @value;
    
        public EndpointAffinity(ScriptDom.AffinityKind kind = ScriptDom.AffinityKind.NotSpecified, Literal @value = null) {
            this.kind = kind;
            this.@value = @value;
        }
    
        public ScriptDom.EndpointAffinity ToMutableConcrete() {
            var ret = new ScriptDom.EndpointAffinity();
            ret.Kind = kind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + kind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EndpointAffinity);
        } 
        
        public bool Equals(EndpointAffinity other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AffinityKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EndpointAffinity left, EndpointAffinity right) {
            return EqualityComparer<EndpointAffinity>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EndpointAffinity left, EndpointAffinity right) {
            return !(left == right);
        }
    
    }

}
