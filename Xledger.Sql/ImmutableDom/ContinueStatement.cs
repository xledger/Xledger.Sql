using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ContinueStatement : TSqlStatement, IEquatable<ContinueStatement> {
        public ContinueStatement() {

        }
    
        public ScriptDom.ContinueStatement ToMutableConcrete() {
            var ret = new ScriptDom.ContinueStatement();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ContinueStatement);
        } 
        
        public bool Equals(ContinueStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(ContinueStatement left, ContinueStatement right) {
            return EqualityComparer<ContinueStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ContinueStatement left, ContinueStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ContinueStatement)that;
            return compare;
        } 
        
        public static bool operator < (ContinueStatement left, ContinueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ContinueStatement left, ContinueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ContinueStatement left, ContinueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ContinueStatement left, ContinueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ContinueStatement FromMutable(ScriptDom.ContinueStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ContinueStatement)) { throw new NotImplementedException("Unexpected subtype of ContinueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ContinueStatement(
                
            );
        }
    
    }

}
