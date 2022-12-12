using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CloseCursorStatement : CursorStatement, IEquatable<CloseCursorStatement> {
        public CloseCursorStatement(CursorId cursor = null) {
            this.cursor = cursor;
        }
    
        public ScriptDom.CloseCursorStatement ToMutableConcrete() {
            var ret = new ScriptDom.CloseCursorStatement();
            ret.Cursor = (ScriptDom.CursorId)cursor.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(cursor is null)) {
                h = h * 23 + cursor.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CloseCursorStatement);
        } 
        
        public bool Equals(CloseCursorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<CursorId>.Default.Equals(other.Cursor, cursor)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CloseCursorStatement left, CloseCursorStatement right) {
            return EqualityComparer<CloseCursorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CloseCursorStatement left, CloseCursorStatement right) {
            return !(left == right);
        }
    
    }

}
