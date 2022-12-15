using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SubqueryComparisonPredicate : BooleanExpression, IEquatable<SubqueryComparisonPredicate> {
        protected ScalarExpression expression;
        protected ScriptDom.BooleanComparisonType comparisonType = ScriptDom.BooleanComparisonType.Equals;
        protected ScalarSubquery subquery;
        protected ScriptDom.SubqueryComparisonPredicateType subqueryComparisonPredicateType = ScriptDom.SubqueryComparisonPredicateType.None;
    
        public ScalarExpression Expression => expression;
        public ScriptDom.BooleanComparisonType ComparisonType => comparisonType;
        public ScalarSubquery Subquery => subquery;
        public ScriptDom.SubqueryComparisonPredicateType SubqueryComparisonPredicateType => subqueryComparisonPredicateType;
    
        public SubqueryComparisonPredicate(ScalarExpression expression = null, ScriptDom.BooleanComparisonType comparisonType = ScriptDom.BooleanComparisonType.Equals, ScalarSubquery subquery = null, ScriptDom.SubqueryComparisonPredicateType subqueryComparisonPredicateType = ScriptDom.SubqueryComparisonPredicateType.None) {
            this.expression = expression;
            this.comparisonType = comparisonType;
            this.subquery = subquery;
            this.subqueryComparisonPredicateType = subqueryComparisonPredicateType;
        }
    
        public ScriptDom.SubqueryComparisonPredicate ToMutableConcrete() {
            var ret = new ScriptDom.SubqueryComparisonPredicate();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.ComparisonType = comparisonType;
            ret.Subquery = (ScriptDom.ScalarSubquery)subquery.ToMutable();
            ret.SubqueryComparisonPredicateType = subqueryComparisonPredicateType;
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
            h = h * 23 + comparisonType.GetHashCode();
            if (!(subquery is null)) {
                h = h * 23 + subquery.GetHashCode();
            }
            h = h * 23 + subqueryComparisonPredicateType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SubqueryComparisonPredicate);
        } 
        
        public bool Equals(SubqueryComparisonPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BooleanComparisonType>.Default.Equals(other.ComparisonType, comparisonType)) {
                return false;
            }
            if (!EqualityComparer<ScalarSubquery>.Default.Equals(other.Subquery, subquery)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SubqueryComparisonPredicateType>.Default.Equals(other.SubqueryComparisonPredicateType, subqueryComparisonPredicateType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) {
            return EqualityComparer<SubqueryComparisonPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SubqueryComparisonPredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.comparisonType, othr.comparisonType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.subquery, othr.subquery);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.subqueryComparisonPredicateType, othr.subqueryComparisonPredicateType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SubqueryComparisonPredicate left, SubqueryComparisonPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
