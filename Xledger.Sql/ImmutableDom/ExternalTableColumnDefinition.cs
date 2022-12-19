using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableColumnDefinition : TSqlFragment, IEquatable<ExternalTableColumnDefinition> {
        protected ColumnDefinitionBase columnDefinition;
        protected NullableConstraintDefinition nullableConstraint;
    
        public ColumnDefinitionBase ColumnDefinition => columnDefinition;
        public NullableConstraintDefinition NullableConstraint => nullableConstraint;
    
        public ExternalTableColumnDefinition(ColumnDefinitionBase columnDefinition = null, NullableConstraintDefinition nullableConstraint = null) {
            this.columnDefinition = columnDefinition;
            this.nullableConstraint = nullableConstraint;
        }
    
        public ScriptDom.ExternalTableColumnDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableColumnDefinition();
            ret.ColumnDefinition = (ScriptDom.ColumnDefinitionBase)columnDefinition?.ToMutable();
            ret.NullableConstraint = (ScriptDom.NullableConstraintDefinition)nullableConstraint?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnDefinition is null)) {
                h = h * 23 + columnDefinition.GetHashCode();
            }
            if (!(nullableConstraint is null)) {
                h = h * 23 + nullableConstraint.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalTableColumnDefinition);
        } 
        
        public bool Equals(ExternalTableColumnDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnDefinitionBase>.Default.Equals(other.ColumnDefinition, columnDefinition)) {
                return false;
            }
            if (!EqualityComparer<NullableConstraintDefinition>.Default.Equals(other.NullableConstraint, nullableConstraint)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) {
            return EqualityComparer<ExternalTableColumnDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalTableColumnDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnDefinition, othr.columnDefinition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.nullableConstraint, othr.nullableConstraint);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalTableColumnDefinition left, ExternalTableColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalTableColumnDefinition FromMutable(ScriptDom.ExternalTableColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalTableColumnDefinition)) { throw new NotImplementedException("Unexpected subtype of ExternalTableColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableColumnDefinition(
                columnDefinition: ImmutableDom.ColumnDefinitionBase.FromMutable(fragment.ColumnDefinition),
                nullableConstraint: ImmutableDom.NullableConstraintDefinition.FromMutable(fragment.NullableConstraint)
            );
        }
    
    }

}
