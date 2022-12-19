using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GrantStatement : SecurityStatement, IEquatable<GrantStatement> {
        protected bool withGrantOption = false;
    
        public bool WithGrantOption => withGrantOption;
    
        public GrantStatement(bool withGrantOption = false, IReadOnlyList<Permission> permissions = null, SecurityTargetObject securityTargetObject = null, IReadOnlyList<SecurityPrincipal> principals = null, Identifier asClause = null) {
            this.withGrantOption = withGrantOption;
            this.permissions = ImmList<Permission>.FromList(permissions);
            this.securityTargetObject = securityTargetObject;
            this.principals = ImmList<SecurityPrincipal>.FromList(principals);
            this.asClause = asClause;
        }
    
        public ScriptDom.GrantStatement ToMutableConcrete() {
            var ret = new ScriptDom.GrantStatement();
            ret.WithGrantOption = withGrantOption;
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
            h = h * 23 + withGrantOption.GetHashCode();
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
            return Equals(obj as GrantStatement);
        } 
        
        public bool Equals(GrantStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithGrantOption, withGrantOption)) {
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
        
        public static bool operator ==(GrantStatement left, GrantStatement right) {
            return EqualityComparer<GrantStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GrantStatement left, GrantStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GrantStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.withGrantOption, othr.withGrantOption);
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
        
        public static bool operator < (GrantStatement left, GrantStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GrantStatement left, GrantStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GrantStatement left, GrantStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GrantStatement left, GrantStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GrantStatement FromMutable(ScriptDom.GrantStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GrantStatement)) { throw new NotImplementedException("Unexpected subtype of GrantStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrantStatement(
                withGrantOption: fragment.WithGrantOption,
                permissions: fragment.Permissions.SelectList(ImmutableDom.Permission.FromMutable),
                securityTargetObject: ImmutableDom.SecurityTargetObject.FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(ImmutableDom.SecurityPrincipal.FromMutable),
                asClause: ImmutableDom.Identifier.FromMutable(fragment.AsClause)
            );
        }
    
    }

}
