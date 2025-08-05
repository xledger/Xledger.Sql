using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectFunctionReturnType : FunctionReturnType, IEquatable<SelectFunctionReturnType> {
        protected SelectStatement selectStatement;
    
        public SelectStatement SelectStatement => selectStatement;
    
        public SelectFunctionReturnType(SelectStatement selectStatement = null) {
            this.selectStatement = selectStatement;
        }
    
        public ScriptDom.SelectFunctionReturnType ToMutableConcrete() {
            var ret = new ScriptDom.SelectFunctionReturnType();
            ret.SelectStatement = (ScriptDom.SelectStatement)selectStatement?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(selectStatement is null)) {
                h = h * 23 + selectStatement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectFunctionReturnType);
        } 
        
        public bool Equals(SelectFunctionReturnType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SelectStatement>.Default.Equals(other.SelectStatement, selectStatement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectFunctionReturnType left, SelectFunctionReturnType right) {
            return EqualityComparer<SelectFunctionReturnType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectFunctionReturnType left, SelectFunctionReturnType right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectFunctionReturnType)that;
            compare = Comparer.DefaultInvariant.Compare(this.selectStatement, othr.selectStatement);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SelectFunctionReturnType left, SelectFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectFunctionReturnType left, SelectFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectFunctionReturnType left, SelectFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectFunctionReturnType left, SelectFunctionReturnType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SelectFunctionReturnType FromMutable(ScriptDom.SelectFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SelectFunctionReturnType)) { throw new NotImplementedException("Unexpected subtype of SelectFunctionReturnType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectFunctionReturnType(
                selectStatement: ImmutableDom.SelectStatement.FromMutable(fragment.SelectStatement)
            );
        }
    
    }

}
