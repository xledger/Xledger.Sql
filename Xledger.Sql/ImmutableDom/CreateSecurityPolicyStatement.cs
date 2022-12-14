using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSecurityPolicyStatement : SecurityPolicyStatement, IEquatable<CreateSecurityPolicyStatement> {
        public CreateSecurityPolicyStatement(SchemaObjectName name = null, bool notForReplication = false, IReadOnlyList<SecurityPolicyOption> securityPolicyOptions = null, IReadOnlyList<SecurityPredicateAction> securityPredicateActions = null, ScriptDom.SecurityPolicyActionType actionType = ScriptDom.SecurityPolicyActionType.Create) {
            this.name = name;
            this.notForReplication = notForReplication;
            this.securityPolicyOptions = ImmList<SecurityPolicyOption>.FromList(securityPolicyOptions);
            this.securityPredicateActions = ImmList<SecurityPredicateAction>.FromList(securityPredicateActions);
            this.actionType = actionType;
        }
    
        public ScriptDom.CreateSecurityPolicyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSecurityPolicyStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.NotForReplication = notForReplication;
            ret.SecurityPolicyOptions.AddRange(securityPolicyOptions.SelectList(c => (ScriptDom.SecurityPolicyOption)c.ToMutable()));
            ret.SecurityPredicateActions.AddRange(securityPredicateActions.SelectList(c => (ScriptDom.SecurityPredicateAction)c.ToMutable()));
            ret.ActionType = actionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + notForReplication.GetHashCode();
            h = h * 23 + securityPolicyOptions.GetHashCode();
            h = h * 23 + securityPredicateActions.GetHashCode();
            h = h * 23 + actionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSecurityPolicyStatement);
        } 
        
        public bool Equals(CreateSecurityPolicyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NotForReplication, notForReplication)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SecurityPolicyOption>>.Default.Equals(other.SecurityPolicyOptions, securityPolicyOptions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SecurityPredicateAction>>.Default.Equals(other.SecurityPredicateActions, securityPredicateActions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SecurityPolicyActionType>.Default.Equals(other.ActionType, actionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSecurityPolicyStatement left, CreateSecurityPolicyStatement right) {
            return EqualityComparer<CreateSecurityPolicyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSecurityPolicyStatement left, CreateSecurityPolicyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSecurityPolicyStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.notForReplication, othr.notForReplication);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.securityPolicyOptions, othr.securityPolicyOptions);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.securityPredicateActions, othr.securityPredicateActions);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.actionType, othr.actionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static CreateSecurityPolicyStatement FromMutable(ScriptDom.CreateSecurityPolicyStatement fragment) {
            return (CreateSecurityPolicyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
