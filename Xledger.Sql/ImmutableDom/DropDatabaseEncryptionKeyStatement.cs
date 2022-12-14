using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropDatabaseEncryptionKeyStatement : TSqlStatement, IEquatable<DropDatabaseEncryptionKeyStatement> {
        public DropDatabaseEncryptionKeyStatement() {

        }
    
        public ScriptDom.DropDatabaseEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropDatabaseEncryptionKeyStatement();
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
            return Equals(obj as DropDatabaseEncryptionKeyStatement);
        } 
        
        public bool Equals(DropDatabaseEncryptionKeyStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) {
            return EqualityComparer<DropDatabaseEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropDatabaseEncryptionKeyStatement)that;
            return compare;
        } 
        public static bool operator < (DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropDatabaseEncryptionKeyStatement left, DropDatabaseEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropDatabaseEncryptionKeyStatement FromMutable(ScriptDom.DropDatabaseEncryptionKeyStatement fragment) {
            return (DropDatabaseEncryptionKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
