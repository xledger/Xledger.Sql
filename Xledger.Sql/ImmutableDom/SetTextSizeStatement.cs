using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetTextSizeStatement : TSqlStatement, IEquatable<SetTextSizeStatement> {
        ScalarExpression textSize;
    
        public ScalarExpression TextSize => textSize;
    
        public SetTextSizeStatement(ScalarExpression textSize = null) {
            this.textSize = textSize;
        }
    
        public ScriptDom.SetTextSizeStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetTextSizeStatement();
            ret.TextSize = (ScriptDom.ScalarExpression)textSize.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(textSize is null)) {
                h = h * 23 + textSize.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetTextSizeStatement);
        } 
        
        public bool Equals(SetTextSizeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.TextSize, textSize)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetTextSizeStatement left, SetTextSizeStatement right) {
            return EqualityComparer<SetTextSizeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetTextSizeStatement left, SetTextSizeStatement right) {
            return !(left == right);
        }
    
    }

}
