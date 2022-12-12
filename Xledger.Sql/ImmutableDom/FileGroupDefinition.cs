using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileGroupDefinition : TSqlFragment, IEquatable<FileGroupDefinition> {
        Identifier name;
        IReadOnlyList<FileDeclaration> fileDeclarations;
        bool isDefault = false;
        bool containsFileStream = false;
        bool containsMemoryOptimizedData = false;
    
        public Identifier Name => name;
        public IReadOnlyList<FileDeclaration> FileDeclarations => fileDeclarations;
        public bool IsDefault => isDefault;
        public bool ContainsFileStream => containsFileStream;
        public bool ContainsMemoryOptimizedData => containsMemoryOptimizedData;
    
        public FileGroupDefinition(Identifier name = null, IReadOnlyList<FileDeclaration> fileDeclarations = null, bool isDefault = false, bool containsFileStream = false, bool containsMemoryOptimizedData = false) {
            this.name = name;
            this.fileDeclarations = fileDeclarations is null ? ImmList<FileDeclaration>.Empty : ImmList<FileDeclaration>.FromList(fileDeclarations);
            this.isDefault = isDefault;
            this.containsFileStream = containsFileStream;
            this.containsMemoryOptimizedData = containsMemoryOptimizedData;
        }
    
        public ScriptDom.FileGroupDefinition ToMutableConcrete() {
            var ret = new ScriptDom.FileGroupDefinition();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.FileDeclarations.AddRange(fileDeclarations.Select(c => (ScriptDom.FileDeclaration)c.ToMutable()));
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
    
    }

}
