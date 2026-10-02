using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateVectorIndexStatement : IndexStatement, IEquatable<CreateVectorIndexStatement> {
        protected Identifier vectorColumn;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
    
        public Identifier VectorColumn => vectorColumn;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
    
        public CreateVectorIndexStatement(Identifier vectorColumn = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.vectorColumn = vectorColumn;
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.name = name;
            this.onName = onName;
            this.indexOptions = indexOptions.ToImmArray<IndexOption>();
        }
    
        public ScriptDom.CreateVectorIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateVectorIndexStatement();
            ret.VectorColumn = (ScriptDom.Identifier)vectorColumn?.ToMutable();
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName?.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(vectorColumn is null)) {
                h = h * 23 + vectorColumn.GetHashCode();
            }
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateVectorIndexStatement);
        } 
        
        public bool Equals(CreateVectorIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.VectorColumn, vectorColumn)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateVectorIndexStatement left, CreateVectorIndexStatement right) {
            return EqualityComparer<CreateVectorIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateVectorIndexStatement left, CreateVectorIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateVectorIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.vectorColumn, othr.vectorColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroupOrPartitionScheme, othr.onFileGroupOrPartitionScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateVectorIndexStatement left, CreateVectorIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateVectorIndexStatement left, CreateVectorIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateVectorIndexStatement left, CreateVectorIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateVectorIndexStatement left, CreateVectorIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateVectorIndexStatement FromMutable(ScriptDom.CreateVectorIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateVectorIndexStatement)) { throw new NotImplementedException("Unexpected subtype of CreateVectorIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateVectorIndexStatement(
                vectorColumn: ImmutableDom.Identifier.FromMutable(fragment.VectorColumn),
                onFileGroupOrPartitionScheme: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OnFileGroupOrPartitionScheme),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                onName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable)
            );
        }
    
    }

}
