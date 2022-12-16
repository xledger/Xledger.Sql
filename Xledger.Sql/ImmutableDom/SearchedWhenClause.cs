using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SearchedWhenClause : WhenClause, IEquatable<SearchedWhenClause> {
        protected BooleanExpression whenExpression;
    
        public BooleanExpression WhenExpression => whenExpression;
    
        public SearchedWhenClause(BooleanExpression whenExpression = null, ScalarExpression thenExpression = null) {
            this.whenExpression = whenExpression;
            this.thenExpression = thenExpression;
        }
    
        public ScriptDom.SearchedWhenClause ToMutableConcrete() {
            var ret = new ScriptDom.SearchedWhenClause();
            ret.WhenExpression = (ScriptDom.BooleanExpression)whenExpression?.ToMutable();
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
            return Equals(obj as SearchedWhenClause);
        } 
        
        public bool Equals(SearchedWhenClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.WhenExpression, whenExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ThenExpression, thenExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SearchedWhenClause left, SearchedWhenClause right) {
            return EqualityComparer<SearchedWhenClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SearchedWhenClause left, SearchedWhenClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SearchedWhenClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.whenExpression, othr.whenExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.thenExpression, othr.thenExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SearchedWhenClause left, SearchedWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SearchedWhenClause left, SearchedWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SearchedWhenClause left, SearchedWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SearchedWhenClause left, SearchedWhenClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
