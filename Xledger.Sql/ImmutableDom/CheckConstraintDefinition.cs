using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CheckConstraintDefinition : ConstraintDefinition, IEquatable<CheckConstraintDefinition> {
        protected BooleanExpression checkCondition;
        protected bool notForReplication = false;
    
        public BooleanExpression CheckCondition => checkCondition;
        public bool NotForReplication => notForReplication;
    
        public CheckConstraintDefinition(BooleanExpression checkCondition = null, bool notForReplication = false, Identifier constraintIdentifier = null) {
            this.checkCondition = checkCondition;
            this.notForReplication = notForReplication;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.CheckConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.CheckConstraintDefinition();
            ret.CheckCondition = (ScriptDom.BooleanExpression)checkCondition?.ToMutable();
            ret.NotForReplication = notForReplication;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CheckConstraintDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.checkCondition, othr.checkCondition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.notForReplication, othr.notForReplication);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.constraintIdentifier, othr.constraintIdentifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CheckConstraintDefinition left, CheckConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CheckConstraintDefinition left, CheckConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CheckConstraintDefinition left, CheckConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CheckConstraintDefinition left, CheckConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CheckConstraintDefinition FromMutable(ScriptDom.CheckConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CheckConstraintDefinition)) { throw new NotImplementedException("Unexpected subtype of CheckConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CheckConstraintDefinition(
                checkCondition: ImmutableDom.BooleanExpression.FromMutable(fragment.CheckCondition),
                notForReplication: fragment.NotForReplication,
                constraintIdentifier: ImmutableDom.Identifier.FromMutable(fragment.ConstraintIdentifier)
            );
        }
    
    }

}
