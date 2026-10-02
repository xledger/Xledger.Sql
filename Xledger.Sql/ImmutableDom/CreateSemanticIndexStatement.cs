using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSemanticIndexStatement : IndexStatement, IEquatable<CreateSemanticIndexStatement> {
        protected IReadOnlyList<SemanticIndexColumn> columns;
        protected Identifier externalModelName;
        protected StringLiteral externalModelParameters;
        protected IReadOnlyList<IndexOption> vectorIndexOptions;
        protected StopListFullTextIndexOption fulltextStoplistOption;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
    
        public IReadOnlyList<SemanticIndexColumn> Columns => columns;
        public Identifier ExternalModelName => externalModelName;
        public StringLiteral ExternalModelParameters => externalModelParameters;
        public IReadOnlyList<IndexOption> VectorIndexOptions => vectorIndexOptions;
        public StopListFullTextIndexOption FulltextStoplistOption => fulltextStoplistOption;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
    
        public CreateSemanticIndexStatement(IReadOnlyList<SemanticIndexColumn> columns = null, Identifier externalModelName = null, StringLiteral externalModelParameters = null, IReadOnlyList<IndexOption> vectorIndexOptions = null, StopListFullTextIndexOption fulltextStoplistOption = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.columns = columns.ToImmArray<SemanticIndexColumn>();
            this.externalModelName = externalModelName;
            this.externalModelParameters = externalModelParameters;
            this.vectorIndexOptions = vectorIndexOptions.ToImmArray<IndexOption>();
            this.fulltextStoplistOption = fulltextStoplistOption;
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.name = name;
            this.onName = onName;
            this.indexOptions = indexOptions.ToImmArray<IndexOption>();
        }
    
        public ScriptDom.CreateSemanticIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSemanticIndexStatement();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.SemanticIndexColumn)c?.ToMutable()));
            ret.ExternalModelName = (ScriptDom.Identifier)externalModelName?.ToMutable();
            ret.ExternalModelParameters = (ScriptDom.StringLiteral)externalModelParameters?.ToMutable();
            ret.VectorIndexOptions.AddRange(vectorIndexOptions.Select(c => (ScriptDom.IndexOption)c?.ToMutable()));
            ret.FulltextStoplistOption = (ScriptDom.StopListFullTextIndexOption)fulltextStoplistOption?.ToMutable();
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
            h = h * 23 + columns.GetHashCode();
            if (!(externalModelName is null)) {
                h = h * 23 + externalModelName.GetHashCode();
            }
            if (!(externalModelParameters is null)) {
                h = h * 23 + externalModelParameters.GetHashCode();
            }
            h = h * 23 + vectorIndexOptions.GetHashCode();
            if (!(fulltextStoplistOption is null)) {
                h = h * 23 + fulltextStoplistOption.GetHashCode();
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
            return Equals(obj as CreateSemanticIndexStatement);
        } 
        
        public bool Equals(CreateSemanticIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SemanticIndexColumn>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ExternalModelName, externalModelName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ExternalModelParameters, externalModelParameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.VectorIndexOptions, vectorIndexOptions)) {
                return false;
            }
            if (!EqualityComparer<StopListFullTextIndexOption>.Default.Equals(other.FulltextStoplistOption, fulltextStoplistOption)) {
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
        
        public static bool operator ==(CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) {
            return EqualityComparer<CreateSemanticIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSemanticIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalModelName, othr.externalModelName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalModelParameters, othr.externalModelParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.vectorIndexOptions, othr.vectorIndexOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fulltextStoplistOption, othr.fulltextStoplistOption);
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
        
        public static bool operator < (CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSemanticIndexStatement left, CreateSemanticIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSemanticIndexStatement FromMutable(ScriptDom.CreateSemanticIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSemanticIndexStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSemanticIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSemanticIndexStatement(
                columns: fragment.Columns.ToImmArray(ImmutableDom.SemanticIndexColumn.FromMutable),
                externalModelName: ImmutableDom.Identifier.FromMutable(fragment.ExternalModelName),
                externalModelParameters: ImmutableDom.StringLiteral.FromMutable(fragment.ExternalModelParameters),
                vectorIndexOptions: fragment.VectorIndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable),
                fulltextStoplistOption: ImmutableDom.StopListFullTextIndexOption.FromMutable(fragment.FulltextStoplistOption),
                onFileGroupOrPartitionScheme: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OnFileGroupOrPartitionScheme),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                onName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable)
            );
        }
    
    }

}
