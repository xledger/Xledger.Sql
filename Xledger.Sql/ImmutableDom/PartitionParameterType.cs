using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PartitionParameterType : TSqlFragment, IEquatable<PartitionParameterType> {
        protected DataTypeReference dataType;
        protected Identifier collation;
    
        public DataTypeReference DataType => dataType;
        public Identifier Collation => collation;
    
        public PartitionParameterType(DataTypeReference dataType = null, Identifier collation = null) {
            this.dataType = dataType;
            this.collation = collation;
        }
    
        public ScriptDom.PartitionParameterType ToMutableConcrete() {
            var ret = new ScriptDom.PartitionParameterType();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
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
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PartitionParameterType);
        } 
        
        public bool Equals(PartitionParameterType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PartitionParameterType left, PartitionParameterType right) {
            return EqualityComparer<PartitionParameterType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PartitionParameterType left, PartitionParameterType right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PartitionParameterType)that;
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PartitionParameterType left, PartitionParameterType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PartitionParameterType left, PartitionParameterType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PartitionParameterType left, PartitionParameterType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PartitionParameterType left, PartitionParameterType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PartitionParameterType FromMutable(ScriptDom.PartitionParameterType fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PartitionParameterType)) { throw new NotImplementedException("Unexpected subtype of PartitionParameterType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartitionParameterType(
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
