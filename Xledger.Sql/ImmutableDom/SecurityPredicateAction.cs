using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityPredicateAction : TSqlFragment, IEquatable<SecurityPredicateAction> {
        protected ScriptDom.SecurityPredicateActionType actionType = ScriptDom.SecurityPredicateActionType.Create;
        protected ScriptDom.SecurityPredicateType securityPredicateType = ScriptDom.SecurityPredicateType.Filter;
        protected FunctionCall functionCall;
        protected SchemaObjectName targetObjectName;
        protected ScriptDom.SecurityPredicateOperation securityPredicateOperation = ScriptDom.SecurityPredicateOperation.All;
    
        public ScriptDom.SecurityPredicateActionType ActionType => actionType;
        public ScriptDom.SecurityPredicateType SecurityPredicateType => securityPredicateType;
        public FunctionCall FunctionCall => functionCall;
        public SchemaObjectName TargetObjectName => targetObjectName;
        public ScriptDom.SecurityPredicateOperation SecurityPredicateOperation => securityPredicateOperation;
    
        public SecurityPredicateAction(ScriptDom.SecurityPredicateActionType actionType = ScriptDom.SecurityPredicateActionType.Create, ScriptDom.SecurityPredicateType securityPredicateType = ScriptDom.SecurityPredicateType.Filter, FunctionCall functionCall = null, SchemaObjectName targetObjectName = null, ScriptDom.SecurityPredicateOperation securityPredicateOperation = ScriptDom.SecurityPredicateOperation.All) {
            this.actionType = actionType;
            this.securityPredicateType = securityPredicateType;
            this.functionCall = functionCall;
            this.targetObjectName = targetObjectName;
            this.securityPredicateOperation = securityPredicateOperation;
        }
    
        public ScriptDom.SecurityPredicateAction ToMutableConcrete() {
            var ret = new ScriptDom.SecurityPredicateAction();
            ret.ActionType = actionType;
            ret.SecurityPredicateType = securityPredicateType;
            ret.FunctionCall = (ScriptDom.FunctionCall)functionCall.ToMutable();
            ret.TargetObjectName = (ScriptDom.SchemaObjectName)targetObjectName.ToMutable();
            ret.SecurityPredicateOperation = securityPredicateOperation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + actionType.GetHashCode();
            h = h * 23 + securityPredicateType.GetHashCode();
            if (!(functionCall is null)) {
                h = h * 23 + functionCall.GetHashCode();
            }
            if (!(targetObjectName is null)) {
                h = h * 23 + targetObjectName.GetHashCode();
            }
            h = h * 23 + securityPredicateOperation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityPredicateAction);
        } 
        
        public bool Equals(SecurityPredicateAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SecurityPredicateActionType>.Default.Equals(other.ActionType, actionType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SecurityPredicateType>.Default.Equals(other.SecurityPredicateType, securityPredicateType)) {
                return false;
            }
            if (!EqualityComparer<FunctionCall>.Default.Equals(other.FunctionCall, functionCall)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TargetObjectName, targetObjectName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SecurityPredicateOperation>.Default.Equals(other.SecurityPredicateOperation, securityPredicateOperation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityPredicateAction left, SecurityPredicateAction right) {
            return EqualityComparer<SecurityPredicateAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityPredicateAction left, SecurityPredicateAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecurityPredicateAction)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.actionType, othr.actionType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.securityPredicateType, othr.securityPredicateType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.functionCall, othr.functionCall);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.targetObjectName, othr.targetObjectName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.securityPredicateOperation, othr.securityPredicateOperation);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SecurityPredicateAction FromMutable(ScriptDom.SecurityPredicateAction fragment) {
            return (SecurityPredicateAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
