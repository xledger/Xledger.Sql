using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecondaryRoleReplicaOption : AvailabilityReplicaOption, IEquatable<SecondaryRoleReplicaOption> {
        protected ScriptDom.AllowConnectionsOptionKind allowConnections = ScriptDom.AllowConnectionsOptionKind.No;
    
        public ScriptDom.AllowConnectionsOptionKind AllowConnections => allowConnections;
    
        public SecondaryRoleReplicaOption(ScriptDom.AllowConnectionsOptionKind allowConnections = ScriptDom.AllowConnectionsOptionKind.No, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.allowConnections = allowConnections;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.SecondaryRoleReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.SecondaryRoleReplicaOption();
            ret.AllowConnections = allowConnections;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + allowConnections.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecondaryRoleReplicaOption);
        } 
        
        public bool Equals(SecondaryRoleReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AllowConnectionsOptionKind>.Default.Equals(other.AllowConnections, allowConnections)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) {
            return EqualityComparer<SecondaryRoleReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecondaryRoleReplicaOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.allowConnections, othr.allowConnections);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SecondaryRoleReplicaOption left, SecondaryRoleReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SecondaryRoleReplicaOption FromMutable(ScriptDom.SecondaryRoleReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SecondaryRoleReplicaOption)) { throw new NotImplementedException("Unexpected subtype of SecondaryRoleReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecondaryRoleReplicaOption(
                allowConnections: fragment.AllowConnections,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
