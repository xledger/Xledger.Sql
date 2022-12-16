using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseAddFileGroupStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseAddFileGroupStatement> {
        protected Identifier fileGroup;
        protected bool containsFileStream = false;
        protected bool containsMemoryOptimizedData = false;
    
        public Identifier FileGroup => fileGroup;
        public bool ContainsFileStream => containsFileStream;
        public bool ContainsMemoryOptimizedData => containsMemoryOptimizedData;
    
        public AlterDatabaseAddFileGroupStatement(Identifier fileGroup = null, bool containsFileStream = false, bool containsMemoryOptimizedData = false, Identifier databaseName = null, bool useCurrent = false) {
            this.fileGroup = fileGroup;
            this.containsFileStream = containsFileStream;
            this.containsMemoryOptimizedData = containsMemoryOptimizedData;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseAddFileGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseAddFileGroupStatement();
            ret.FileGroup = (ScriptDom.Identifier)fileGroup?.ToMutable();
            ret.ContainsFileStream = containsFileStream;
            ret.ContainsMemoryOptimizedData = containsMemoryOptimizedData;
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
            h = h * 23 + containsFileStream.GetHashCode();
            h = h * 23 + containsMemoryOptimizedData.GetHashCode();
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseAddFileGroupStatement);
        } 
        
        public bool Equals(AlterDatabaseAddFileGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ContainsFileStream, containsFileStream)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ContainsMemoryOptimizedData, containsMemoryOptimizedData)) {
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
        
        public static bool operator ==(AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) {
            return EqualityComparer<AlterDatabaseAddFileGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseAddFileGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileGroup, othr.fileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.containsFileStream, othr.containsFileStream);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.containsMemoryOptimizedData, othr.containsMemoryOptimizedData);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseAddFileGroupStatement left, AlterDatabaseAddFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
