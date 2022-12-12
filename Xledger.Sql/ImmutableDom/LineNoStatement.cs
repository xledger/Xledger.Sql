using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LineNoStatement : TSqlStatement, IEquatable<LineNoStatement> {
        protected IntegerLiteral lineNo;
    
        public IntegerLiteral LineNo => lineNo;
    
        public LineNoStatement(IntegerLiteral lineNo = null) {
            this.lineNo = lineNo;
        }
    
        public ScriptDom.LineNoStatement ToMutableConcrete() {
            var ret = new ScriptDom.LineNoStatement();
            ret.LineNo = (ScriptDom.IntegerLiteral)lineNo.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(lineNo is null)) {
                h = h * 23 + lineNo.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LineNoStatement);
        } 
        
        public bool Equals(LineNoStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.LineNo, lineNo)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LineNoStatement left, LineNoStatement right) {
            return EqualityComparer<LineNoStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LineNoStatement left, LineNoStatement right) {
            return !(left == right);
        }
    
    }

}
