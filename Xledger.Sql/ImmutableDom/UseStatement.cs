using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UseStatement : TSqlStatement, IEquatable<UseStatement> {
        protected Identifier databaseName;
    
        public Identifier DatabaseName => databaseName;
    
        public UseStatement(Identifier databaseName = null) {
            this.databaseName = databaseName;
        }
    
        public ScriptDom.UseStatement ToMutableConcrete() {
            var ret = new ScriptDom.UseStatement();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UseStatement);
        } 
        
        public bool Equals(UseStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UseStatement left, UseStatement right) {
            return EqualityComparer<UseStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UseStatement left, UseStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UseStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UseStatement left, UseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UseStatement left, UseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UseStatement left, UseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UseStatement left, UseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UseStatement FromMutable(ScriptDom.UseStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UseStatement)) { throw new NotImplementedException("Unexpected subtype of UseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UseStatement(
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName)
            );
        }
    
    }

}
