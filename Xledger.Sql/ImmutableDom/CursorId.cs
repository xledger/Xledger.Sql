using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorId : TSqlFragment, IEquatable<CursorId> {
        protected bool isGlobal = false;
        protected IdentifierOrValueExpression name;
    
        public bool IsGlobal => isGlobal;
        public IdentifierOrValueExpression Name => name;
    
        public CursorId(bool isGlobal = false, IdentifierOrValueExpression name = null) {
            this.isGlobal = isGlobal;
            this.name = name;
        }
    
        public ScriptDom.CursorId ToMutableConcrete() {
            var ret = new ScriptDom.CursorId();
            ret.IsGlobal = isGlobal;
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isGlobal.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CursorId);
        } 
        
        public bool Equals(CursorId other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsGlobal, isGlobal)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorId left, CursorId right) {
            return EqualityComparer<CursorId>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorId left, CursorId right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CursorId)that;
            compare = Comparer.DefaultInvariant.Compare(this.isGlobal, othr.isGlobal);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CursorId left, CursorId right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CursorId left, CursorId right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CursorId left, CursorId right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CursorId left, CursorId right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CursorId FromMutable(ScriptDom.CursorId fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CursorId)) { throw new NotImplementedException("Unexpected subtype of CursorId not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorId(
                isGlobal: fragment.IsGlobal,
                name: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.Name)
            );
        }
    
    }

}
