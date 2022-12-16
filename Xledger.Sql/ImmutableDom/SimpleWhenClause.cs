using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SimpleWhenClause : WhenClause, IEquatable<SimpleWhenClause> {
        protected ScalarExpression whenExpression;
    
        public ScalarExpression WhenExpression => whenExpression;
    
        public SimpleWhenClause(ScalarExpression whenExpression = null, ScalarExpression thenExpression = null) {
            this.whenExpression = whenExpression;
            this.thenExpression = thenExpression;
        }
    
        public ScriptDom.SimpleWhenClause ToMutableConcrete() {
            var ret = new ScriptDom.SimpleWhenClause();
            ret.WhenExpression = (ScriptDom.ScalarExpression)whenExpression?.ToMutable();
            ret.ThenExpression = (ScriptDom.ScalarExpression)thenExpression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(whenExpression is null)) {
                h = h * 23 + whenExpression.GetHashCode();
            }
            if (!(thenExpression is null)) {
                h = h * 23 + thenExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SimpleWhenClause);
        } 
        
        public bool Equals(SimpleWhenClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.WhenExpression, whenExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ThenExpression, thenExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SimpleWhenClause left, SimpleWhenClause right) {
            return EqualityComparer<SimpleWhenClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SimpleWhenClause left, SimpleWhenClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SimpleWhenClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.whenExpression, othr.whenExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.thenExpression, othr.thenExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SimpleWhenClause left, SimpleWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SimpleWhenClause left, SimpleWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SimpleWhenClause left, SimpleWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SimpleWhenClause left, SimpleWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
