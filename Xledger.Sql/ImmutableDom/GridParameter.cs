using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GridParameter : TSqlFragment, IEquatable<GridParameter> {
        protected ScriptDom.GridParameterType parameter = ScriptDom.GridParameterType.None;
        protected ScriptDom.ImportanceParameterType @value = ScriptDom.ImportanceParameterType.Unknown;
    
        public ScriptDom.GridParameterType Parameter => parameter;
        public ScriptDom.ImportanceParameterType Value => @value;
    
        public GridParameter(ScriptDom.GridParameterType parameter = ScriptDom.GridParameterType.None, ScriptDom.ImportanceParameterType @value = ScriptDom.ImportanceParameterType.Unknown) {
            this.parameter = parameter;
            this.@value = @value;
        }
    
        public ScriptDom.GridParameter ToMutableConcrete() {
            var ret = new ScriptDom.GridParameter();
            ret.Parameter = parameter;
            ret.Value = @value;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameter.GetHashCode();
            h = h * 23 + @value.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GridParameter);
        } 
        
        public bool Equals(GridParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.GridParameterType>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ImportanceParameterType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GridParameter left, GridParameter right) {
            return EqualityComparer<GridParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GridParameter left, GridParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GridParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameter, othr.parameter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GridParameter left, GridParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GridParameter left, GridParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GridParameter left, GridParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GridParameter left, GridParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GridParameter FromMutable(ScriptDom.GridParameter fragment) {
            return (GridParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
