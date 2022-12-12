using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectStarExpression : SelectElement, IEquatable<SelectStarExpression> {
        MultiPartIdentifier qualifier;
    
        public MultiPartIdentifier Qualifier => qualifier;
    
        public SelectStarExpression(MultiPartIdentifier qualifier = null) {
            this.qualifier = qualifier;
        }
    
        public ScriptDom.SelectStarExpression ToMutableConcrete() {
            var ret = new ScriptDom.SelectStarExpression();
            ret.Qualifier = (ScriptDom.MultiPartIdentifier)qualifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(qualifier is null)) {
                h = h * 23 + qualifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectStarExpression);
        } 
        
        public bool Equals(SelectStarExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.Qualifier, qualifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectStarExpression left, SelectStarExpression right) {
            return EqualityComparer<SelectStarExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectStarExpression left, SelectStarExpression right) {
            return !(left == right);
        }
    
    }

}
