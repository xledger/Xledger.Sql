using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BoundingBoxParameter : TSqlFragment, IEquatable<BoundingBoxParameter> {
        protected ScriptDom.BoundingBoxParameterType parameter = ScriptDom.BoundingBoxParameterType.None;
        protected ScalarExpression @value;
    
        public ScriptDom.BoundingBoxParameterType Parameter => parameter;
        public ScalarExpression Value => @value;
    
        public BoundingBoxParameter(ScriptDom.BoundingBoxParameterType parameter = ScriptDom.BoundingBoxParameterType.None, ScalarExpression @value = null) {
            this.parameter = parameter;
            this.@value = @value;
        }
    
        public ScriptDom.BoundingBoxParameter ToMutableConcrete() {
            var ret = new ScriptDom.BoundingBoxParameter();
            ret.Parameter = parameter;
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameter.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BoundingBoxParameter);
        } 
        
        public bool Equals(BoundingBoxParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BoundingBoxParameterType>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BoundingBoxParameter left, BoundingBoxParameter right) {
            return EqualityComparer<BoundingBoxParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BoundingBoxParameter left, BoundingBoxParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BoundingBoxParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameter, othr.parameter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (BoundingBoxParameter left, BoundingBoxParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BoundingBoxParameter left, BoundingBoxParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BoundingBoxParameter left, BoundingBoxParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BoundingBoxParameter left, BoundingBoxParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
