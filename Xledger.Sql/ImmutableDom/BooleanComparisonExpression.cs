using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanComparisonExpression : BooleanExpression, IEquatable<BooleanComparisonExpression> {
        ScriptDom.BooleanComparisonType comparisonType = ScriptDom.BooleanComparisonType.Equals;
        ScalarExpression firstExpression;
        ScalarExpression secondExpression;
    
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
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression.ToMutable();
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
    
    }

}
