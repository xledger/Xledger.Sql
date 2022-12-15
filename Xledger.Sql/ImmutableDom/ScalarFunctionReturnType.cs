using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarFunctionReturnType : FunctionReturnType, IEquatable<ScalarFunctionReturnType> {
        protected DataTypeReference dataType;
    
        public DataTypeReference DataType => dataType;
    
        public ScalarFunctionReturnType(DataTypeReference dataType = null) {
            this.dataType = dataType;
        }
    
        public ScriptDom.ScalarFunctionReturnType ToMutableConcrete() {
            var ret = new ScriptDom.ScalarFunctionReturnType();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ScalarFunctionReturnType);
        } 
        
        public bool Equals(ScalarFunctionReturnType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarFunctionReturnType left, ScalarFunctionReturnType right) {
            return EqualityComparer<ScalarFunctionReturnType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarFunctionReturnType left, ScalarFunctionReturnType right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ScalarFunctionReturnType)that;
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ScalarFunctionReturnType left, ScalarFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ScalarFunctionReturnType left, ScalarFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ScalarFunctionReturnType left, ScalarFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ScalarFunctionReturnType left, ScalarFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
