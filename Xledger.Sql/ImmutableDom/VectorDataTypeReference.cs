using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VectorDataTypeReference : DataTypeReference, IEquatable<VectorDataTypeReference> {
        protected IntegerLiteral dimension;
        protected Identifier baseType;
    
        public IntegerLiteral Dimension => dimension;
        public Identifier BaseType => baseType;
    
        public VectorDataTypeReference(IntegerLiteral dimension = null, Identifier baseType = null, SchemaObjectName name = null) {
            this.dimension = dimension;
            this.baseType = baseType;
            this.name = name;
        }
    
        public ScriptDom.VectorDataTypeReference ToMutableConcrete() {
            var ret = new ScriptDom.VectorDataTypeReference();
            ret.Dimension = (ScriptDom.IntegerLiteral)dimension?.ToMutable();
            ret.BaseType = (ScriptDom.Identifier)baseType?.ToMutable();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dimension is null)) {
                h = h * 23 + dimension.GetHashCode();
            }
            if (!(baseType is null)) {
                h = h * 23 + baseType.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VectorDataTypeReference);
        } 
        
        public bool Equals(VectorDataTypeReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.Dimension, dimension)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.BaseType, baseType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VectorDataTypeReference left, VectorDataTypeReference right) {
            return EqualityComparer<VectorDataTypeReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VectorDataTypeReference left, VectorDataTypeReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VectorDataTypeReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.dimension, othr.dimension);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.baseType, othr.baseType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (VectorDataTypeReference left, VectorDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VectorDataTypeReference left, VectorDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VectorDataTypeReference left, VectorDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VectorDataTypeReference left, VectorDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VectorDataTypeReference FromMutable(ScriptDom.VectorDataTypeReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.VectorDataTypeReference)) { throw new NotImplementedException("Unexpected subtype of VectorDataTypeReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VectorDataTypeReference(
                dimension: ImmutableDom.IntegerLiteral.FromMutable(fragment.Dimension),
                baseType: ImmutableDom.Identifier.FromMutable(fragment.BaseType),
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name)
            );
        }
    
    }

}
