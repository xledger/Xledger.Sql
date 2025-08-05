using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanComparisonExpression : BooleanExpression, IEquatable<BooleanComparisonExpression> {
        protected ScriptDom.BooleanComparisonType comparisonType = ScriptDom.BooleanComparisonType.Equals;
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
    
        public ScriptDom.BooleanComparisonType ComparisonType => comparisonType;
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
    
        public BooleanComparisonExpression(ScriptDom.BooleanComparisonType comparisonType = ScriptDom.BooleanComparisonType.Equals, ScalarExpression firstExpression = null, ScalarExpression secondExpression = null) {
            this.comparisonType = comparisonType;
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
        }
    
        public ScriptDom.BooleanComparisonExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanComparisonExpression();
            ret.ComparisonType = comparisonType;
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression?.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + comparisonType.GetHashCode();
            if (!(firstExpression is null)) {
                h = h * 23 + firstExpression.GetHashCode();
            }
            if (!(secondExpression is null)) {
                h = h * 23 + secondExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanComparisonExpression);
        } 
        
        public bool Equals(BooleanComparisonExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BooleanComparisonType>.Default.Equals(other.ComparisonType, comparisonType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanComparisonExpression left, BooleanComparisonExpression right) {
            return EqualityComparer<BooleanComparisonExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanComparisonExpression left, BooleanComparisonExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BooleanComparisonExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.comparisonType, othr.comparisonType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BooleanComparisonExpression left, BooleanComparisonExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BooleanComparisonExpression left, BooleanComparisonExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BooleanComparisonExpression left, BooleanComparisonExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BooleanComparisonExpression left, BooleanComparisonExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BooleanComparisonExpression FromMutable(ScriptDom.BooleanComparisonExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BooleanComparisonExpression)) { throw new NotImplementedException("Unexpected subtype of BooleanComparisonExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanComparisonExpression(
                comparisonType: fragment.ComparisonType,
                firstExpression: ImmutableDom.ScalarExpression.FromMutable(fragment.FirstExpression),
                secondExpression: ImmutableDom.ScalarExpression.FromMutable(fragment.SecondExpression)
            );
        }
    
    }

}
