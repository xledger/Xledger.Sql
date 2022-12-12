using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanTernaryExpression : BooleanExpression, IEquatable<BooleanTernaryExpression> {
        protected ScriptDom.BooleanTernaryExpressionType ternaryExpressionType = ScriptDom.BooleanTernaryExpressionType.Between;
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
        protected ScalarExpression thirdExpression;
    
        public ScriptDom.BooleanTernaryExpressionType TernaryExpressionType => ternaryExpressionType;
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
        public ScalarExpression ThirdExpression => thirdExpression;
    
        public BooleanTernaryExpression(ScriptDom.BooleanTernaryExpressionType ternaryExpressionType = ScriptDom.BooleanTernaryExpressionType.Between, ScalarExpression firstExpression = null, ScalarExpression secondExpression = null, ScalarExpression thirdExpression = null) {
            this.ternaryExpressionType = ternaryExpressionType;
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.thirdExpression = thirdExpression;
        }
    
        public ScriptDom.BooleanTernaryExpression ToMutableConcrete() {
            var ret = new ScriptDom.BooleanTernaryExpression();
            ret.TernaryExpressionType = ternaryExpressionType;
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression.ToMutable();
            ret.ThirdExpression = (ScriptDom.ScalarExpression)thirdExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + ternaryExpressionType.GetHashCode();
            if (!(firstExpression is null)) {
                h = h * 23 + firstExpression.GetHashCode();
            }
            if (!(secondExpression is null)) {
                h = h * 23 + secondExpression.GetHashCode();
            }
            if (!(thirdExpression is null)) {
                h = h * 23 + thirdExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanTernaryExpression);
        } 
        
        public bool Equals(BooleanTernaryExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BooleanTernaryExpressionType>.Default.Equals(other.TernaryExpressionType, ternaryExpressionType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ThirdExpression, thirdExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanTernaryExpression left, BooleanTernaryExpression right) {
            return EqualityComparer<BooleanTernaryExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanTernaryExpression left, BooleanTernaryExpression right) {
            return !(left == right);
        }
    
    }

}
