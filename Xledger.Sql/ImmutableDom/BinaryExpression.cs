using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BinaryExpression : ScalarExpression, IEquatable<BinaryExpression> {
        protected ScriptDom.BinaryExpressionType binaryExpressionType = ScriptDom.BinaryExpressionType.Add;
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
    
        public ScriptDom.BinaryExpressionType BinaryExpressionType => binaryExpressionType;
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
    
        public BinaryExpression(ScriptDom.BinaryExpressionType binaryExpressionType = ScriptDom.BinaryExpressionType.Add, ScalarExpression firstExpression = null, ScalarExpression secondExpression = null) {
            this.binaryExpressionType = binaryExpressionType;
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
        }
    
        public ScriptDom.BinaryExpression ToMutableConcrete() {
            var ret = new ScriptDom.BinaryExpression();
            ret.BinaryExpressionType = binaryExpressionType;
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression?.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression?.ToMutable();
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
            return Equals(obj as BinaryExpression);
        } 
        
        public bool Equals(BinaryExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BinaryExpressionType>.Default.Equals(other.BinaryExpressionType, binaryExpressionType)) {
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
        
        public static bool operator ==(BinaryExpression left, BinaryExpression right) {
            return EqualityComparer<BinaryExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BinaryExpression left, BinaryExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BinaryExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.binaryExpressionType, othr.binaryExpressionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (BinaryExpression left, BinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BinaryExpression left, BinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BinaryExpression left, BinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BinaryExpression left, BinaryExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
