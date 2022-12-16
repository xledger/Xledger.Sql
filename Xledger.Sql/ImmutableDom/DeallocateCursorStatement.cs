using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeallocateCursorStatement : CursorStatement, IEquatable<DeallocateCursorStatement> {
        public DeallocateCursorStatement(CursorId cursor = null) {
            this.cursor = cursor;
        }
    
        public ScriptDom.DeallocateCursorStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeallocateCursorStatement();
            ret.Cursor = (ScriptDom.CursorId)cursor?.ToMutable();
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
            return Equals(obj as DeallocateCursorStatement);
        } 
        
        public bool Equals(DeallocateCursorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<CursorId>.Default.Equals(other.Cursor, cursor)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeallocateCursorStatement left, DeallocateCursorStatement right) {
            return EqualityComparer<DeallocateCursorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeallocateCursorStatement left, DeallocateCursorStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeallocateCursorStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.cursor, othr.cursor);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DeallocateCursorStatement left, DeallocateCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeallocateCursorStatement left, DeallocateCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeallocateCursorStatement left, DeallocateCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeallocateCursorStatement left, DeallocateCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
