using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableValuedFunctionReturnType : FunctionReturnType, IEquatable<TableValuedFunctionReturnType> {
        protected DeclareTableVariableBody declareTableVariableBody;
    
        public DeclareTableVariableBody DeclareTableVariableBody => declareTableVariableBody;
    
        public TableValuedFunctionReturnType(DeclareTableVariableBody declareTableVariableBody = null) {
            this.declareTableVariableBody = declareTableVariableBody;
        }
    
        public ScriptDom.TableValuedFunctionReturnType ToMutableConcrete() {
            var ret = new ScriptDom.TableValuedFunctionReturnType();
            ret.DeclareTableVariableBody = (ScriptDom.DeclareTableVariableBody)declareTableVariableBody?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(declareTableVariableBody is null)) {
                h = h * 23 + declareTableVariableBody.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableValuedFunctionReturnType);
        } 
        
        public bool Equals(TableValuedFunctionReturnType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DeclareTableVariableBody>.Default.Equals(other.DeclareTableVariableBody, declareTableVariableBody)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) {
            return EqualityComparer<TableValuedFunctionReturnType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableValuedFunctionReturnType)that;
            compare = Comparer.DefaultInvariant.Compare(this.declareTableVariableBody, othr.declareTableVariableBody);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableValuedFunctionReturnType left, TableValuedFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
