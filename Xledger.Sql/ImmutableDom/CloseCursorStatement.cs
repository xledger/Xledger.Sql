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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CloseCursorStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.cursor, othr.cursor);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CloseCursorStatement left, CloseCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CloseCursorStatement left, CloseCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CloseCursorStatement left, CloseCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CloseCursorStatement left, CloseCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CloseCursorStatement FromMutable(ScriptDom.CloseCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CloseCursorStatement)) { throw new NotImplementedException("Unexpected subtype of CloseCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CloseCursorStatement(
                cursor: ImmutableDom.CursorId.FromMutable(fragment.Cursor)
            );
        }
    
    }

}
