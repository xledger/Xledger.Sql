using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseRemoveFileGroupStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseRemoveFileGroupStatement> {
        protected Identifier fileGroup;
    
        public Identifier FileGroup => fileGroup;
    
        public AlterDatabaseRemoveFileGroupStatement(Identifier fileGroup = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileGroup = fileGroup;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseRemoveFileGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseRemoveFileGroupStatement();
            ret.FileGroup = (ScriptDom.Identifier)fileGroup?.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseRemoveFileGroupStatement);
        } 
        
        public bool Equals(AlterDatabaseRemoveFileGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
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
        
        public static bool operator ==(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) {
            return EqualityComparer<AlterDatabaseRemoveFileGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseRemoveFileGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileGroup, othr.fileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabaseRemoveFileGroupStatement FromMutable(ScriptDom.AlterDatabaseRemoveFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabaseRemoveFileGroupStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseRemoveFileGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseRemoveFileGroupStatement(
                fileGroup: ImmutableDom.Identifier.FromMutable(fragment.FileGroup),
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
    
    }

}
