using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanBinaryExpression : BooleanExpression, IEquatable<BooleanBinaryExpression> {
        protected ScriptDom.BooleanBinaryExpressionType binaryExpressionType = ScriptDom.BooleanBinaryExpressionType.And;
        protected BooleanExpression firstExpression;
        protected BooleanExpression secondExpression;
    
        public ScriptDom.BooleanBinaryExpressionType BinaryExpressionType => binaryExpressionType;
        public BooleanExpression FirstExpression => firstExpression;
        public BooleanExpression SecondExpression => secondExpression;
    
        public BooleanBinaryExpression(ScriptDom.BooleanBinaryExpressionType binaryExpressionType = ScriptDom.BooleanBinaryExpressionType.And, BooleanExpression firstExpression = null, BooleanExpression secondExpression = null) {
            this.binaryExpressionType = binaryExpressionType;
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
        }
    
        public ScriptDom.BooleanBinaryExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanBinaryExpression();
            ret.BinaryExpressionType = binaryExpressionType;
            ret.FirstExpression = (ScriptDom.BooleanExpression)firstExpression?.ToMutable();
            ret.SecondExpression = (ScriptDom.BooleanExpression)secondExpression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + binaryExpressionType.GetHashCode();
            if (!(firstExpression is null)) {
                h = h * 23 + firstExpression.GetHashCode();
            }
            if (!(secondExpression is null)) {
                h = h * 23 + secondExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanBinaryExpression);
        } 
        
        public bool Equals(BooleanBinaryExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BooleanBinaryExpressionType>.Default.Equals(other.BinaryExpressionType, binaryExpressionType)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanBinaryExpression left, BooleanBinaryExpression right) {
            return EqualityComparer<BooleanBinaryExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanBinaryExpression left, BooleanBinaryExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BooleanBinaryExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.binaryExpressionType, othr.binaryExpressionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BooleanBinaryExpression left, BooleanBinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BooleanBinaryExpression left, BooleanBinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BooleanBinaryExpression left, BooleanBinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BooleanBinaryExpression left, BooleanBinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BooleanBinaryExpression FromMutable(ScriptDom.BooleanBinaryExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BooleanBinaryExpression)) { throw new NotImplementedException("Unexpected subtype of BooleanBinaryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanBinaryExpression(
                binaryExpressionType: fragment.BinaryExpressionType,
                firstExpression: ImmutableDom.BooleanExpression.FromMutable(fragment.FirstExpression),
                secondExpression: ImmutableDom.BooleanExpression.FromMutable(fragment.SecondExpression)
            );
        }
    
    }

}
