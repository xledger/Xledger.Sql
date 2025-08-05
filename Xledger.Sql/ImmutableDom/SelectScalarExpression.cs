using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectScalarExpression : SelectElement, IEquatable<SelectScalarExpression> {
        protected ScalarExpression expression;
        protected IdentifierOrValueExpression columnName;
    
        public ScalarExpression Expression => expression;
        public IdentifierOrValueExpression ColumnName => columnName;
    
        public SelectScalarExpression(ScalarExpression expression = null, IdentifierOrValueExpression columnName = null) {
            this.expression = expression;
            this.columnName = columnName;
        }
    
        public ScriptDom.SelectScalarExpression ToMutableConcrete() {
            var ret = new ScriptDom.SelectScalarExpression();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            ret.ColumnName = (ScriptDom.IdentifierOrValueExpression)columnName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            if (!(columnName is null)) {
                h = h * 23 + columnName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectScalarExpression);
        } 
        
        public bool Equals(SelectScalarExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.ColumnName, columnName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectScalarExpression left, SelectScalarExpression right) {
            return EqualityComparer<SelectScalarExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectScalarExpression left, SelectScalarExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectScalarExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnName, othr.columnName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SelectScalarExpression left, SelectScalarExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectScalarExpression left, SelectScalarExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectScalarExpression left, SelectScalarExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectScalarExpression left, SelectScalarExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SelectScalarExpression FromMutable(ScriptDom.SelectScalarExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SelectScalarExpression)) { throw new NotImplementedException("Unexpected subtype of SelectScalarExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectScalarExpression(
                expression: ImmutableDom.ScalarExpression.FromMutable(fragment.Expression),
                columnName: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.ColumnName)
            );
        }
    
    }

}
