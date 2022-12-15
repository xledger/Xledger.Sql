using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAuthorizationStatement : TSqlStatement, IEquatable<AlterAuthorizationStatement> {
        protected SecurityTargetObject securityTargetObject;
        protected bool toSchemaOwner = false;
        protected Identifier principalName;
    
        public SecurityTargetObject SecurityTargetObject => securityTargetObject;
        public bool ToSchemaOwner => toSchemaOwner;
        public Identifier PrincipalName => principalName;
    
        public AlterAuthorizationStatement(SecurityTargetObject securityTargetObject = null, bool toSchemaOwner = false, Identifier principalName = null) {
            this.securityTargetObject = securityTargetObject;
            this.toSchemaOwner = toSchemaOwner;
            this.principalName = principalName;
        }
    
        public ScriptDom.AlterAuthorizationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAuthorizationStatement();
            ret.SecurityTargetObject = (ScriptDom.SecurityTargetObject)securityTargetObject.ToMutable();
            ret.ToSchemaOwner = toSchemaOwner;
            ret.PrincipalName = (ScriptDom.Identifier)principalName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(securityTargetObject is null)) {
                h = h * 23 + securityTargetObject.GetHashCode();
            }
            h = h * 23 + toSchemaOwner.GetHashCode();
            if (!(principalName is null)) {
                h = h * 23 + principalName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAuthorizationStatement);
        } 
        
        public bool Equals(AlterAuthorizationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SecurityTargetObject>.Default.Equals(other.SecurityTargetObject, securityTargetObject)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ToSchemaOwner, toSchemaOwner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PrincipalName, principalName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAuthorizationStatement left, AlterAuthorizationStatement right) {
            return EqualityComparer<AlterAuthorizationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAuthorizationStatement left, AlterAuthorizationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterAuthorizationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.securityTargetObject, othr.securityTargetObject);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.toSchemaOwner, othr.toSchemaOwner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.principalName, othr.principalName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterAuthorizationStatement left, AlterAuthorizationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterAuthorizationStatement left, AlterAuthorizationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterAuthorizationStatement left, AlterAuthorizationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterAuthorizationStatement left, AlterAuthorizationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
