using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CheckConstraintDefinition : ConstraintDefinition, IEquatable<CheckConstraintDefinition> {
        BooleanExpression checkCondition;
        bool notForReplication = false;
    
        public BooleanExpression CheckCondition => checkCondition;
        public bool NotForReplication => notForReplication;
    
        public CheckConstraintDefinition(BooleanExpression checkCondition = null, bool notForReplication = false, Identifier constraintIdentifier = null) {
            this.checkCondition = checkCondition;
            this.notForReplication = notForReplication;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.CheckConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.CheckConstraintDefinition();
            ret.CheckCondition = (ScriptDom.BooleanExpression)checkCondition.ToMutable();
            ret.NotForReplication = notForReplication;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(checkCondition is null)) {
                h = h * 23 + checkCondition.GetHashCode();
            }
            h = h * 23 + notForReplication.GetHashCode();
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CheckConstraintDefinition);
        } 
        
        public bool Equals(CheckConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.CheckCondition, checkCondition)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NotForReplication, notForReplication)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CheckConstraintDefinition left, CheckConstraintDefinition right) {
            return EqualityComparer<CheckConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CheckConstraintDefinition left, CheckConstraintDefinition right) {
            return !(left == right);
        }
    
    }

}
