using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DefaultConstraintDefinition : ConstraintDefinition, IEquatable<DefaultConstraintDefinition> {
        protected ScalarExpression expression;
        protected bool withValues = false;
        protected Identifier column;
    
        public ScalarExpression Expression => expression;
        public bool WithValues => withValues;
        public Identifier Column => column;
    
        public DefaultConstraintDefinition(ScalarExpression expression = null, bool withValues = false, Identifier column = null, Identifier constraintIdentifier = null) {
            this.expression = expression;
            this.withValues = withValues;
            this.column = column;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.DefaultConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.DefaultConstraintDefinition();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            ret.WithValues = withValues;
            ret.Column = (ScriptDom.Identifier)column?.ToMutable();
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            h = h * 23 + withValues.GetHashCode();
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DefaultConstraintDefinition);
        } 
        
        public bool Equals(DefaultConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithValues, withValues)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DefaultConstraintDefinition left, DefaultConstraintDefinition right) {
            return EqualityComparer<DefaultConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DefaultConstraintDefinition left, DefaultConstraintDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DefaultConstraintDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withValues, othr.withValues);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.column, othr.column);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.constraintIdentifier, othr.constraintIdentifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DefaultConstraintDefinition left, DefaultConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DefaultConstraintDefinition left, DefaultConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DefaultConstraintDefinition left, DefaultConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DefaultConstraintDefinition left, DefaultConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
