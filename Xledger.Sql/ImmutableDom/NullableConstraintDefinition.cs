using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NullableConstraintDefinition : ConstraintDefinition, IEquatable<NullableConstraintDefinition> {
        bool nullable = false;
    
        public bool Nullable => nullable;
    
        public NullableConstraintDefinition(bool nullable = false, Identifier constraintIdentifier = null) {
            this.nullable = nullable;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.NullableConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.NullableConstraintDefinition();
            ret.Nullable = nullable;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier.ToMutable();
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
    
    }

}