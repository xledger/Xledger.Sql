using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditActionSpecification : AuditSpecificationDetail, IEquatable<AuditActionSpecification> {
        protected IReadOnlyList<DatabaseAuditAction> actions;
        protected IReadOnlyList<SecurityPrincipal> principals;
        protected SecurityTargetObject targetObject;
    
        public IReadOnlyList<DatabaseAuditAction> Actions => actions;
        public IReadOnlyList<SecurityPrincipal> Principals => principals;
        public SecurityTargetObject TargetObject => targetObject;
    
        public AuditActionSpecification(IReadOnlyList<DatabaseAuditAction> actions = null, IReadOnlyList<SecurityPrincipal> principals = null, SecurityTargetObject targetObject = null) {
            this.actions = actions is null ? ImmList<DatabaseAuditAction>.Empty : ImmList<DatabaseAuditAction>.FromList(actions);
            this.principals = principals is null ? ImmList<SecurityPrincipal>.Empty : ImmList<SecurityPrincipal>.FromList(principals);
            this.targetObject = targetObject;
        }
    
        public ScriptDom.AuditActionSpecification ToMutableConcrete() {
            var ret = new ScriptDom.AuditActionSpecification();
            ret.Actions.AddRange(actions.SelectList(c => (ScriptDom.DatabaseAuditAction)c.ToMutable()));
            ret.Principals.AddRange(principals.SelectList(c => (ScriptDom.SecurityPrincipal)c.ToMutable()));
            ret.TargetObject = (ScriptDom.SecurityTargetObject)targetObject.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + actions.GetHashCode();
            h = h * 23 + principals.GetHashCode();
            if (!(targetObject is null)) {
                h = h * 23 + targetObject.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuditActionSpecification);
        } 
        
        public bool Equals(AuditActionSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<DatabaseAuditAction>>.Default.Equals(other.Actions, actions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SecurityPrincipal>>.Default.Equals(other.Principals, principals)) {
                return false;
            }
            if (!EqualityComparer<SecurityTargetObject>.Default.Equals(other.TargetObject, targetObject)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuditActionSpecification left, AuditActionSpecification right) {
            return EqualityComparer<AuditActionSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuditActionSpecification left, AuditActionSpecification right) {
            return !(left == right);
        }
    
    }

}
