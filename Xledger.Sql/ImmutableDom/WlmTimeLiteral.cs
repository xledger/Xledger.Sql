using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WlmTimeLiteral : TSqlFragment, IEquatable<WlmTimeLiteral> {
        StringLiteral timeString;
    
        public StringLiteral TimeString => timeString;
    
        public WlmTimeLiteral(StringLiteral timeString = null) {
            this.timeString = timeString;
        }
    
        public ScriptDom.WlmTimeLiteral ToMutableConcrete() {
            var ret = new ScriptDom.WlmTimeLiteral();
            ret.TimeString = (ScriptDom.StringLiteral)timeString.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(timeString is null)) {
                h = h * 23 + timeString.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WlmTimeLiteral);
        } 
        
        public bool Equals(WlmTimeLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.TimeString, timeString)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WlmTimeLiteral left, WlmTimeLiteral right) {
            return EqualityComparer<WlmTimeLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WlmTimeLiteral left, WlmTimeLiteral right) {
            return !(left == right);
        }
    
    }

}
