using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileGroupDefinition : TSqlFragment, IEquatable<FileGroupDefinition> {
        protected Identifier name;
        protected IReadOnlyList<FileDeclaration> fileDeclarations;
        protected bool isDefault = false;
        protected bool containsFileStream = false;
        protected bool containsMemoryOptimizedData = false;
    
        public Identifier Name => name;
        public IReadOnlyList<FileDeclaration> FileDeclarations => fileDeclarations;
        public bool IsDefault => isDefault;
        public bool ContainsFileStream => containsFileStream;
        public bool ContainsMemoryOptimizedData => containsMemoryOptimizedData;
    
        public FileGroupDefinition(Identifier name = null, IReadOnlyList<FileDeclaration> fileDeclarations = null, bool isDefault = false, bool containsFileStream = false, bool containsMemoryOptimizedData = false) {
            this.name = name;
            this.fileDeclarations = ImmList<FileDeclaration>.FromList(fileDeclarations);
            this.isDefault = isDefault;
            this.containsFileStream = containsFileStream;
            this.containsMemoryOptimizedData = containsMemoryOptimizedData;
        }
    
        public ScriptDom.FileGroupDefinition ToMutableConcrete() {
            var ret = new ScriptDom.FileGroupDefinition();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.FileDeclarations.AddRange(fileDeclarations.SelectList(c => (ScriptDom.FileDeclaration)c.ToMutable()));
            ret.IsDefault = isDefault;
            ret.ContainsFileStream = containsFileStream;
            ret.ContainsMemoryOptimizedData = containsMemoryOptimizedData;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + fileDeclarations.GetHashCode();
            h = h * 23 + isDefault.GetHashCode();
            h = h * 23 + containsFileStream.GetHashCode();
            h = h * 23 + containsMemoryOptimizedData.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileGroupDefinition);
        } 
        
        public bool Equals(FileGroupDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FileDeclaration>>.Default.Equals(other.FileDeclarations, fileDeclarations)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDefault, isDefault)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ContainsFileStream, containsFileStream)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ContainsMemoryOptimizedData, containsMemoryOptimizedData)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileGroupDefinition left, FileGroupDefinition right) {
            return EqualityComparer<FileGroupDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileGroupDefinition left, FileGroupDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileGroupDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileDeclarations, othr.fileDeclarations);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isDefault, othr.isDefault);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.containsFileStream, othr.containsFileStream);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.containsMemoryOptimizedData, othr.containsMemoryOptimizedData);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileGroupDefinition left, FileGroupDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileGroupDefinition left, FileGroupDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileGroupDefinition left, FileGroupDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileGroupDefinition left, FileGroupDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileGroupDefinition FromMutable(ScriptDom.FileGroupDefinition fragment) {
            return (FileGroupDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
