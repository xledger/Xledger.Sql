using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseAddFileStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseAddFileStatement> {
        protected IReadOnlyList<FileDeclaration> fileDeclarations;
        protected Identifier fileGroup;
        protected bool isLog = false;
    
        public IReadOnlyList<FileDeclaration> FileDeclarations => fileDeclarations;
        public Identifier FileGroup => fileGroup;
        public bool IsLog => isLog;
    
        public AlterDatabaseAddFileStatement(IReadOnlyList<FileDeclaration> fileDeclarations = null, Identifier fileGroup = null, bool isLog = false, Identifier databaseName = null, bool useCurrent = false) {
            this.fileDeclarations = ImmList<FileDeclaration>.FromList(fileDeclarations);
            this.fileGroup = fileGroup;
            this.isLog = isLog;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseAddFileStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseAddFileStatement();
            ret.FileDeclarations.AddRange(fileDeclarations.SelectList(c => (ScriptDom.FileDeclaration)c.ToMutable()));
            ret.FileGroup = (ScriptDom.Identifier)fileGroup.ToMutable();
            ret.IsLog = isLog;
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + fileDeclarations.GetHashCode();
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            h = h * 23 + isLog.GetHashCode();
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseAddFileStatement);
        } 
        
        public bool Equals(AlterDatabaseAddFileStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<FileDeclaration>>.Default.Equals(other.FileDeclarations, fileDeclarations)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsLog, isLog)) {
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
        
        public static bool operator ==(AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) {
            return EqualityComparer<AlterDatabaseAddFileStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseAddFileStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileDeclarations, othr.fileDeclarations);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileGroup, othr.fileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isLog, othr.isLog);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseAddFileStatement left, AlterDatabaseAddFileStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
