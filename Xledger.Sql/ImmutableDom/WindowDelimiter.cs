using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowDelimiter : TSqlFragment, IEquatable<WindowDelimiter> {
        protected ScriptDom.WindowDelimiterType windowDelimiterType = ScriptDom.WindowDelimiterType.UnboundedPreceding;
        protected ScalarExpression offsetValue;
    
        public ScriptDom.WindowDelimiterType WindowDelimiterType => windowDelimiterType;
        public ScalarExpression OffsetValue => offsetValue;
    
        public WindowDelimiter(ScriptDom.WindowDelimiterType windowDelimiterType = ScriptDom.WindowDelimiterType.UnboundedPreceding, ScalarExpression offsetValue = null) {
            this.windowDelimiterType = windowDelimiterType;
            this.offsetValue = offsetValue;
        }
    
        public ScriptDom.WindowDelimiter ToMutableConcrete() {
            var ret = new ScriptDom.WindowDelimiter();
            ret.WindowDelimiterType = windowDelimiterType;
            ret.OffsetValue = (ScriptDom.ScalarExpression)offsetValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + windowDelimiterType.GetHashCode();
            if (!(offsetValue is null)) {
                h = h * 23 + offsetValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WindowDelimiter);
        } 
        
        public bool Equals(WindowDelimiter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.WindowDelimiterType>.Default.Equals(other.WindowDelimiterType, windowDelimiterType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.OffsetValue, offsetValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WindowDelimiter left, WindowDelimiter right) {
            return EqualityComparer<WindowDelimiter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowDelimiter left, WindowDelimiter right) {
            return !(left == right);
        }
    
    }

}
