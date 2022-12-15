using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityPrincipal : TSqlFragment, IEquatable<SecurityPrincipal> {
        protected ScriptDom.PrincipalType principalType = ScriptDom.PrincipalType.Null;
        protected Identifier identifier;
    
        public ScriptDom.PrincipalType PrincipalType => principalType;
        public Identifier Identifier => identifier;
    
        public SecurityPrincipal(ScriptDom.PrincipalType principalType = ScriptDom.PrincipalType.Null, Identifier identifier = null) {
            this.principalType = principalType;
            this.identifier = identifier;
        }
    
        public ScriptDom.SecurityPrincipal ToMutableConcrete() {
            var ret = new ScriptDom.SecurityPrincipal();
            ret.PrincipalType = principalType;
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + principalType.GetHashCode();
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityPrincipal);
        } 
        
        public bool Equals(SecurityPrincipal other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PrincipalType>.Default.Equals(other.PrincipalType, principalType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityPrincipal left, SecurityPrincipal right) {
            return EqualityComparer<SecurityPrincipal>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityPrincipal left, SecurityPrincipal right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecurityPrincipal)that;
            compare = Comparer.DefaultInvariant.Compare(this.principalType, othr.principalType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SecurityPrincipal left, SecurityPrincipal right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SecurityPrincipal left, SecurityPrincipal right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SecurityPrincipal left, SecurityPrincipal right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SecurityPrincipal left, SecurityPrincipal right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
