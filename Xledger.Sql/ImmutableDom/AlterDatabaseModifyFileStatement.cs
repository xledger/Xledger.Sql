using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseModifyFileStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseModifyFileStatement> {
        protected FileDeclaration fileDeclaration;
    
        public FileDeclaration FileDeclaration => fileDeclaration;
    
        public AlterDatabaseModifyFileStatement(FileDeclaration fileDeclaration = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileDeclaration = fileDeclaration;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseModifyFileStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseModifyFileStatement();
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
            return Equals(obj as AlterDatabaseModifyFileStatement);
        } 
        
        public bool Equals(AlterDatabaseModifyFileStatement other) {
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
        
        public static bool operator ==(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) {
            return EqualityComparer<AlterDatabaseModifyFileStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseModifyFileStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileDeclaration, othr.fileDeclaration);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabaseModifyFileStatement FromMutable(ScriptDom.AlterDatabaseModifyFileStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabaseModifyFileStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseModifyFileStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseModifyFileStatement(
                fileDeclaration: ImmutableDom.FileDeclaration.FromMutable(fragment.FileDeclaration),
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
    
    }

}
