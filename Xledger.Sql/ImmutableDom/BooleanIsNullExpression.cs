using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanIsNullExpression : BooleanExpression, IEquatable<BooleanIsNullExpression> {
        protected bool isNot = false;
        protected ScalarExpression expression;
    
        public bool IsNot => isNot;
        public ScalarExpression Expression => expression;
    
        public BooleanIsNullExpression(bool isNot = false, ScalarExpression expression = null) {
            this.isNot = isNot;
            this.expression = expression;
        }
    
        public ScriptDom.BooleanIsNullExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanIsNullExpression();
            ret.IsNot = isNot;
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isNot.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanIsNullExpression);
        } 
        
        public bool Equals(BooleanIsNullExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNot, isNot)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanIsNullExpression left, BooleanIsNullExpression right) {
            return EqualityComparer<BooleanIsNullExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanIsNullExpression left, BooleanIsNullExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BooleanIsNullExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.isNot, othr.isNot);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BooleanIsNullExpression left, BooleanIsNullExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BooleanIsNullExpression left, BooleanIsNullExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BooleanIsNullExpression left, BooleanIsNullExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BooleanIsNullExpression left, BooleanIsNullExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BooleanIsNullExpression FromMutable(ScriptDom.BooleanIsNullExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BooleanIsNullExpression)) { throw new NotImplementedException("Unexpected subtype of BooleanIsNullExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanIsNullExpression(
                isNot: fragment.IsNot,
                expression: ImmutableDom.ScalarExpression.FromMutable(fragment.Expression)
            );
        }
    
    }

}
