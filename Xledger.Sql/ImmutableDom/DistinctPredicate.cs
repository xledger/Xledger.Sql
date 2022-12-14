using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DistinctPredicate : BooleanExpression, IEquatable<DistinctPredicate> {
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
        protected bool isNot = false;
    
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
        public bool IsNot => isNot;
    
        public DistinctPredicate(ScalarExpression firstExpression = null, ScalarExpression secondExpression = null, bool isNot = false) {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.isNot = isNot;
        }
    
        public ScriptDom.DistinctPredicate ToMutableConcrete() {
            var ret = new ScriptDom.DistinctPredicate();
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression.ToMutable();
            ret.IsNot = isNot;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(firstExpression is null)) {
                h = h * 23 + firstExpression.GetHashCode();
            }
            if (!(secondExpression is null)) {
                h = h * 23 + secondExpression.GetHashCode();
            }
            h = h * 23 + isNot.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DistinctPredicate);
        } 
        
        public bool Equals(DistinctPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNot, isNot)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DistinctPredicate left, DistinctPredicate right) {
            return EqualityComparer<DistinctPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DistinctPredicate left, DistinctPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DistinctPredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isNot, othr.isNot);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DistinctPredicate left, DistinctPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DistinctPredicate left, DistinctPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DistinctPredicate left, DistinctPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DistinctPredicate left, DistinctPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DistinctPredicate FromMutable(ScriptDom.DistinctPredicate fragment) {
            return (DistinctPredicate)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
