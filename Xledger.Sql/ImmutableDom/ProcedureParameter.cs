using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProcedureParameter : DeclareVariableElement, IEquatable<ProcedureParameter> {
        protected bool isVarying = false;
        protected ScriptDom.ParameterModifier modifier = ScriptDom.ParameterModifier.None;
    
        public bool IsVarying => isVarying;
        public ScriptDom.ParameterModifier Modifier => modifier;
    
        public ProcedureParameter(bool isVarying = false, ScriptDom.ParameterModifier modifier = ScriptDom.ParameterModifier.None, Identifier variableName = null, DataTypeReference dataType = null, NullableConstraintDefinition nullable = null, ScalarExpression @value = null) {
            this.isVarying = isVarying;
            this.modifier = modifier;
            this.variableName = variableName;
            this.dataType = dataType;
            this.nullable = nullable;
            this.@value = @value;
        }
    
        public new ScriptDom.ProcedureParameter ToMutableConcrete() {
            var ret = new ScriptDom.ProcedureParameter();
            ret.IsVarying = isVarying;
            ret.Modifier = modifier;
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
            h = h * 23 + isVarying.GetHashCode();
            h = h * 23 + modifier.GetHashCode();
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
            return Equals(obj as ProcedureParameter);
        } 
        
        public bool Equals(ProcedureParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsVarying, isVarying)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ParameterModifier>.Default.Equals(other.Modifier, modifier)) {
                return false;
            }
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
        
        public static bool operator ==(ProcedureParameter left, ProcedureParameter right) {
            return EqualityComparer<ProcedureParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProcedureParameter left, ProcedureParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ProcedureParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.isVarying, othr.isVarying);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modifier, othr.modifier);
            if (compare != 0) { return compare; }
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
        
        public static bool operator < (ProcedureParameter left, ProcedureParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ProcedureParameter left, ProcedureParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ProcedureParameter left, ProcedureParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ProcedureParameter left, ProcedureParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ProcedureParameter FromMutable(ScriptDom.ProcedureParameter fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ProcedureParameter)) { throw new NotImplementedException("Unexpected subtype of ProcedureParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProcedureParameter(
                isVarying: fragment.IsVarying,
                modifier: fragment.Modifier,
                variableName: ImmutableDom.Identifier.FromMutable(fragment.VariableName),
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType),
                nullable: ImmutableDom.NullableConstraintDefinition.FromMutable(fragment.Nullable),
                @value: ImmutableDom.ScalarExpression.FromMutable(fragment.Value)
            );
        }
    
    }

}
