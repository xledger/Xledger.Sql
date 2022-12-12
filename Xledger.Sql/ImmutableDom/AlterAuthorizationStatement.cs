using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAuthorizationStatement : TSqlStatement, IEquatable<AlterAuthorizationStatement> {
        SecurityTargetObject securityTargetObject;
        bool toSchemaOwner = false;
        Identifier principalName;
    
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
    
    }

}
