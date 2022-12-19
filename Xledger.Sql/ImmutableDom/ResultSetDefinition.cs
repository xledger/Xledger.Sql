using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResultSetDefinition : TSqlFragment, IEquatable<ResultSetDefinition> {
        protected ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline;
    
        public ScriptDom.ResultSetType ResultSetType => resultSetType;
    
        public ResultSetDefinition(ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.resultSetType = resultSetType;
        }
    
        public ScriptDom.ResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ResultSetDefinition();
            ret.ResultSetType = resultSetType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + resultSetType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResultSetDefinition);
        } 
        
        public bool Equals(ResultSetDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ResultSetType>.Default.Equals(other.ResultSetType, resultSetType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResultSetDefinition left, ResultSetDefinition right) {
            return EqualityComparer<ResultSetDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResultSetDefinition left, ResultSetDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ResultSetDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.resultSetType, othr.resultSetType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ResultSetDefinition left, ResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ResultSetDefinition left, ResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ResultSetDefinition left, ResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ResultSetDefinition left, ResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ResultSetDefinition FromMutable(ScriptDom.ResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ResultSetDefinition)) { return TSqlFragment.FromMutable(fragment) as ResultSetDefinition; }
            return new ResultSetDefinition(
                resultSetType: fragment.ResultSetType
            );
        }
    
    }

}
