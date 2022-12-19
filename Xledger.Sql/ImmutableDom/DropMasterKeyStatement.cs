using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropMasterKeyStatement : TSqlStatement, IEquatable<DropMasterKeyStatement> {
        public DropMasterKeyStatement() {

        }
    
        public ScriptDom.DropMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropMasterKeyStatement();
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
            return Equals(obj as DropMasterKeyStatement);
        } 
        
        public bool Equals(DropMasterKeyStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(DropMasterKeyStatement left, DropMasterKeyStatement right) {
            return EqualityComparer<DropMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropMasterKeyStatement left, DropMasterKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropMasterKeyStatement)that;
            return compare;
        } 
        
        public static bool operator < (DropMasterKeyStatement left, DropMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropMasterKeyStatement left, DropMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropMasterKeyStatement left, DropMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropMasterKeyStatement left, DropMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropMasterKeyStatement FromMutable(ScriptDom.DropMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropMasterKeyStatement)) { throw new NotImplementedException("Unexpected subtype of DropMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropMasterKeyStatement(
                
            );
        }
    
    }

}
