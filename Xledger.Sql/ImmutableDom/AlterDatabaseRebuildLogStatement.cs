using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseRebuildLogStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseRebuildLogStatement> {
        protected FileDeclaration fileDeclaration;
    
        public FileDeclaration FileDeclaration => fileDeclaration;
    
        public AlterDatabaseRebuildLogStatement(FileDeclaration fileDeclaration = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileDeclaration = fileDeclaration;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseRebuildLogStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseRebuildLogStatement();
            ret.FileDeclaration = (ScriptDom.FileDeclaration)fileDeclaration?.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileDeclaration is null)) {
                h = h * 23 + fileDeclaration.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseRebuildLogStatement);
        } 
        
        public bool Equals(AlterDatabaseRebuildLogStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FileDeclaration>.Default.Equals(other.FileDeclaration, fileDeclaration)) {
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
        
        public static bool operator ==(AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) {
            return EqualityComparer<AlterDatabaseRebuildLogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseRebuildLogStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileDeclaration, othr.fileDeclaration);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseRebuildLogStatement left, AlterDatabaseRebuildLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
