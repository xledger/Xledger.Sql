using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ShutdownStatement : TSqlStatement, IEquatable<ShutdownStatement> {
        protected bool withNoWait = false;
    
        public bool WithNoWait => withNoWait;
    
        public ShutdownStatement(bool withNoWait = false) {
            this.withNoWait = withNoWait;
        }
    
        public ScriptDom.ShutdownStatement ToMutableConcrete() {
            var ret = new ScriptDom.ShutdownStatement();
            ret.WithNoWait = withNoWait;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withNoWait.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ShutdownStatement);
        } 
        
        public bool Equals(ShutdownStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoWait, withNoWait)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ShutdownStatement left, ShutdownStatement right) {
            return EqualityComparer<ShutdownStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ShutdownStatement left, ShutdownStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ShutdownStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.withNoWait, othr.withNoWait);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ShutdownStatement left, ShutdownStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ShutdownStatement left, ShutdownStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ShutdownStatement left, ShutdownStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ShutdownStatement left, ShutdownStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ShutdownStatement FromMutable(ScriptDom.ShutdownStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ShutdownStatement)) { throw new NotImplementedException("Unexpected subtype of ShutdownStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ShutdownStatement(
                withNoWait: fragment.WithNoWait
            );
        }
    
    }

}
