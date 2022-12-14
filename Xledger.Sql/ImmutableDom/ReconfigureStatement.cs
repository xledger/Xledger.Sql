using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReconfigureStatement : TSqlStatement, IEquatable<ReconfigureStatement> {
        protected bool withOverride = false;
    
        public bool WithOverride => withOverride;
    
        public ReconfigureStatement(bool withOverride = false) {
            this.withOverride = withOverride;
        }
    
        public ScriptDom.ReconfigureStatement ToMutableConcrete() {
            var ret = new ScriptDom.ReconfigureStatement();
            ret.WithOverride = withOverride;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withOverride.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReconfigureStatement);
        } 
        
        public bool Equals(ReconfigureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithOverride, withOverride)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ReconfigureStatement left, ReconfigureStatement right) {
            return EqualityComparer<ReconfigureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReconfigureStatement left, ReconfigureStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ReconfigureStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.withOverride, othr.withOverride);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ReconfigureStatement left, ReconfigureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ReconfigureStatement left, ReconfigureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ReconfigureStatement left, ReconfigureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ReconfigureStatement left, ReconfigureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ReconfigureStatement FromMutable(ScriptDom.ReconfigureStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ReconfigureStatement)) { throw new NotImplementedException("Unexpected subtype of ReconfigureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReconfigureStatement(
                withOverride: fragment.WithOverride
            );
        }
    
    }

}
