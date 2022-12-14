using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeclareVariableElement : TSqlFragment, IEquatable<DeclareVariableElement> {
        protected Identifier variableName;
        protected DataTypeReference dataType;
        protected NullableConstraintDefinition nullable;
        protected ScalarExpression @value;
    
        public Identifier VariableName => variableName;
        public DataTypeReference DataType => dataType;
        public NullableConstraintDefinition Nullable => nullable;
        public ScalarExpression Value => @value;
    
        public DeclareVariableElement(Identifier variableName = null, DataTypeReference dataType = null, NullableConstraintDefinition nullable = null, ScalarExpression @value = null) {
            this.variableName = variableName;
            this.dataType = dataType;
            this.nullable = nullable;
            this.@value = @value;
        }
    
        public ScriptDom.DeclareVariableElement ToMutableConcrete() {
            var ret = new ScriptDom.DeclareVariableElement();
            ret.VariableName = (ScriptDom.Identifier)variableName?.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
            ret.Nullable = (ScriptDom.NullableConstraintDefinition)nullable?.ToMutable();
            ret.Value = (ScriptDom.ScalarExpression)@value?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variableName is null)) {
                h = h * 23 + variableName.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(nullable is null)) {
                h = h * 23 + nullable.GetHashCode();
            }
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeclareVariableElement);
        } 
        
        public bool Equals(DeclareVariableElement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.VariableName, variableName)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<NullableConstraintDefinition>.Default.Equals(other.Nullable, nullable)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeclareVariableElement left, DeclareVariableElement right) {
            return EqualityComparer<DeclareVariableElement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeclareVariableElement left, DeclareVariableElement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeclareVariableElement)that;
            compare = Comparer.DefaultInvariant.Compare(this.variableName, othr.variableName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.nullable, othr.nullable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DeclareVariableElement left, DeclareVariableElement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeclareVariableElement left, DeclareVariableElement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeclareVariableElement left, DeclareVariableElement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeclareVariableElement left, DeclareVariableElement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DeclareVariableElement FromMutable(ScriptDom.DeclareVariableElement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DeclareVariableElement)) { return TSqlFragment.FromMutable(fragment) as DeclareVariableElement; }
            return new DeclareVariableElement(
                variableName: ImmutableDom.Identifier.FromMutable(fragment.VariableName),
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType),
                nullable: ImmutableDom.NullableConstraintDefinition.FromMutable(fragment.Nullable),
                @value: ImmutableDom.ScalarExpression.FromMutable(fragment.Value)
            );
        }
    
    }

}
