using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RolePayloadOption : PayloadOption, IEquatable<RolePayloadOption> {
        protected ScriptDom.DatabaseMirroringEndpointRole role = ScriptDom.DatabaseMirroringEndpointRole.NotSpecified;
    
        public ScriptDom.DatabaseMirroringEndpointRole Role => role;
    
        public RolePayloadOption(ScriptDom.DatabaseMirroringEndpointRole role = ScriptDom.DatabaseMirroringEndpointRole.NotSpecified, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.role = role;
            this.kind = kind;
        }
    
        public ScriptDom.RolePayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.RolePayloadOption();
            ret.Role = role;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + role.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RolePayloadOption);
        } 
        
        public bool Equals(RolePayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseMirroringEndpointRole>.Default.Equals(other.Role, role)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RolePayloadOption left, RolePayloadOption right) {
            return EqualityComparer<RolePayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RolePayloadOption left, RolePayloadOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RolePayloadOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.role, othr.role);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RolePayloadOption left, RolePayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RolePayloadOption left, RolePayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RolePayloadOption left, RolePayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RolePayloadOption left, RolePayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RolePayloadOption FromMutable(ScriptDom.RolePayloadOption fragment) {
            return (RolePayloadOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
