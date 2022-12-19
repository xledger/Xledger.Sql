using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EndpointAffinity : TSqlFragment, IEquatable<EndpointAffinity> {
        protected ScriptDom.AffinityKind kind = ScriptDom.AffinityKind.NotSpecified;
        protected Literal @value;
    
        public ScriptDom.AffinityKind Kind => kind;
        public Literal Value => @value;
    
        public EndpointAffinity(ScriptDom.AffinityKind kind = ScriptDom.AffinityKind.NotSpecified, Literal @value = null) {
            this.kind = kind;
            this.@value = @value;
        }
    
        public ScriptDom.EndpointAffinity ToMutableConcrete() {
            var ret = new ScriptDom.EndpointAffinity();
            ret.Kind = kind;
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EndpointAffinity)that;
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (EndpointAffinity left, EndpointAffinity right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EndpointAffinity left, EndpointAffinity right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EndpointAffinity left, EndpointAffinity right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EndpointAffinity left, EndpointAffinity right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static EndpointAffinity FromMutable(ScriptDom.EndpointAffinity fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.EndpointAffinity)) { throw new NotImplementedException("Unexpected subtype of EndpointAffinity not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EndpointAffinity(
                kind: fragment.Kind,
                @value: ImmutableDom.Literal.FromMutable(fragment.Value)
            );
        }
    
    }

}
