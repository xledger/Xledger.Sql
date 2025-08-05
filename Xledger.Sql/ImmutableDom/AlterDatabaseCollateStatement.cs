using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseCollateStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseCollateStatement> {
        protected Identifier collation;
    
        public Identifier Collation => collation;
    
        public AlterDatabaseCollateStatement(Identifier collation = null, Identifier databaseName = null, bool useCurrent = false) {
            this.collation = collation;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseCollateStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseCollateStatement();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseCollateStatement);
        } 
        
        public bool Equals(AlterDatabaseCollateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) {
            return EqualityComparer<AlterDatabaseCollateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseCollateStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabaseCollateStatement FromMutable(ScriptDom.AlterDatabaseCollateStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabaseCollateStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseCollateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseCollateStatement(
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation),
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
    
    }

}
