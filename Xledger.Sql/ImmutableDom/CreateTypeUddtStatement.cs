using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTypeUddtStatement : CreateTypeStatement, IEquatable<CreateTypeUddtStatement> {
        protected DataTypeReference dataType;
        protected NullableConstraintDefinition nullableConstraint;
    
        public DataTypeReference DataType => dataType;
        public NullableConstraintDefinition NullableConstraint => nullableConstraint;
    
        public CreateTypeUddtStatement(DataTypeReference dataType = null, NullableConstraintDefinition nullableConstraint = null, SchemaObjectName name = null) {
            this.dataType = dataType;
            this.nullableConstraint = nullableConstraint;
            this.name = name;
        }
    
        public ScriptDom.CreateTypeUddtStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTypeUddtStatement();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.NullableConstraint = (ScriptDom.NullableConstraintDefinition)nullableConstraint.ToMutable();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(nullableConstraint is null)) {
                h = h * 23 + nullableConstraint.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateTypeUddtStatement);
        } 
        
        public bool Equals(CreateTypeUddtStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<NullableConstraintDefinition>.Default.Equals(other.NullableConstraint, nullableConstraint)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateTypeUddtStatement left, CreateTypeUddtStatement right) {
            return EqualityComparer<CreateTypeUddtStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateTypeUddtStatement left, CreateTypeUddtStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateTypeUddtStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.nullableConstraint, othr.nullableConstraint);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateTypeUddtStatement left, CreateTypeUddtStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateTypeUddtStatement left, CreateTypeUddtStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateTypeUddtStatement left, CreateTypeUddtStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateTypeUddtStatement left, CreateTypeUddtStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
