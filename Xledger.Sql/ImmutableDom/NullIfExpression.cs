using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NullIfExpression : PrimaryExpression, IEquatable<NullIfExpression> {
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
    
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
    
        public NullIfExpression(ScalarExpression firstExpression = null, ScalarExpression secondExpression = null, Identifier collation = null) {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.collation = collation;
        }
    
        public ScriptDom.NullIfExpression ToMutableConcrete() {
            var ret = new ScriptDom.NullIfExpression();
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
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
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NullIfExpression);
        } 
        
        public bool Equals(NullIfExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NullIfExpression left, NullIfExpression right) {
            return EqualityComparer<NullIfExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NullIfExpression left, NullIfExpression right) {
            return !(left == right);
        }
    
    }

}
