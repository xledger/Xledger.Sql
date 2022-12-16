using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RevokeStatement : SecurityStatement, IEquatable<RevokeStatement> {
        protected bool grantOptionFor = false;
        protected bool cascadeOption = false;
    
        public bool GrantOptionFor => grantOptionFor;
        public bool CascadeOption => cascadeOption;
    
        public RevokeStatement(bool grantOptionFor = false, bool cascadeOption = false, IReadOnlyList<Permission> permissions = null, SecurityTargetObject securityTargetObject = null, IReadOnlyList<SecurityPrincipal> principals = null, Identifier asClause = null) {
            this.grantOptionFor = grantOptionFor;
            this.cascadeOption = cascadeOption;
            this.permissions = ImmList<Permission>.FromList(permissions);
            this.securityTargetObject = securityTargetObject;
            this.principals = ImmList<SecurityPrincipal>.FromList(principals);
            this.asClause = asClause;
        }
    
        public ScriptDom.RevokeStatement ToMutableConcrete() {
            var ret = new ScriptDom.RevokeStatement();
            ret.GrantOptionFor = grantOptionFor;
            ret.CascadeOption = cascadeOption;
            ret.Permissions.AddRange(permissions.SelectList(c => (ScriptDom.Permission)c?.ToMutable()));
            ret.SecurityTargetObject = (ScriptDom.SecurityTargetObject)securityTargetObject?.ToMutable();
            ret.Principals.AddRange(principals.SelectList(c => (ScriptDom.SecurityPrincipal)c?.ToMutable()));
            ret.AsClause = (ScriptDom.Identifier)asClause?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + grantOptionFor.GetHashCode();
            h = h * 23 + cascadeOption.GetHashCode();
            h = h * 23 + permissions.GetHashCode();
            if (!(securityTargetObject is null)) {
                h = h * 23 + securityTargetObject.GetHashCode();
            }
            h = h * 23 + principals.GetHashCode();
            if (!(asClause is null)) {
                h = h * 23 + asClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RevokeStatement);
        } 
        
        public bool Equals(RevokeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.GrantOptionFor, grantOptionFor)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.CascadeOption, cascadeOption)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Permission>>.Default.Equals(other.Permissions, permissions)) {
                return false;
            }
            if (!EqualityComparer<SecurityTargetObject>.Default.Equals(other.SecurityTargetObject, securityTargetObject)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SecurityPrincipal>>.Default.Equals(other.Principals, principals)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AsClause, asClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RevokeStatement left, RevokeStatement right) {
            return EqualityComparer<RevokeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RevokeStatement left, RevokeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RevokeStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.grantOptionFor, othr.grantOptionFor);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.cascadeOption, othr.cascadeOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.permissions, othr.permissions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityTargetObject, othr.securityTargetObject);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.principals, othr.principals);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asClause, othr.asClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RevokeStatement left, RevokeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RevokeStatement left, RevokeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RevokeStatement left, RevokeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RevokeStatement left, RevokeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
