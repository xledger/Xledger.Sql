using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabasePerformCutoverStatement : AlterDatabaseStatement, IEquatable<AlterDatabasePerformCutoverStatement> {
        public AlterDatabasePerformCutoverStatement(Identifier databaseName = null, bool useCurrent = false) {
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabasePerformCutoverStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabasePerformCutoverStatement();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.UseCurrent = useCurrent;
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
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabasePerformCutoverStatement);
        } 
        
        public bool Equals(AlterDatabasePerformCutoverStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) {
            return EqualityComparer<AlterDatabasePerformCutoverStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabasePerformCutoverStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabasePerformCutoverStatement left, AlterDatabasePerformCutoverStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabasePerformCutoverStatement FromMutable(ScriptDom.AlterDatabasePerformCutoverStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabasePerformCutoverStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabasePerformCutoverStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabasePerformCutoverStatement(
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
    
    }

}
