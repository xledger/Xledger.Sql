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
            ret.ColumnDefinition = (ScriptDom.ColumnDefinitionBase)columnDefinition.ToMutable();
            ret.NullableConstraint = (ScriptDom.NullableConstraintDefinition)nullableConstraint.ToMutable();
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
    
    }

}
