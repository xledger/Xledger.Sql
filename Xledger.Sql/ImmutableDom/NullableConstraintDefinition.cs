using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NullableConstraintDefinition : ConstraintDefinition, IEquatable<NullableConstraintDefinition> {
        protected bool nullable = false;
    
        public bool Nullable => nullable;
    
        public NullableConstraintDefinition(bool nullable = false, Identifier constraintIdentifier = null) {
            this.nullable = nullable;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.NullableConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.NullableConstraintDefinition();
            ret.Nullable = nullable;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + nullable.GetHashCode();
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NullableConstraintDefinition);
        } 
        
        public bool Equals(NullableConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Nullable, nullable)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NullableConstraintDefinition left, NullableConstraintDefinition right) {
            return EqualityComparer<NullableConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NullableConstraintDefinition left, NullableConstraintDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (NullableConstraintDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.nullable, othr.nullable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.constraintIdentifier, othr.constraintIdentifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (NullableConstraintDefinition left, NullableConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(NullableConstraintDefinition left, NullableConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (NullableConstraintDefinition left, NullableConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(NullableConstraintDefinition left, NullableConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static NullableConstraintDefinition FromMutable(ScriptDom.NullableConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.NullableConstraintDefinition)) { throw new NotImplementedException("Unexpected subtype of NullableConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NullableConstraintDefinition(
                nullable: fragment.Nullable,
                constraintIdentifier: ImmutableDom.Identifier.FromMutable(fragment.ConstraintIdentifier)
            );
        }
    
    }

}
