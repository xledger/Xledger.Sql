using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexDefinition : TSqlStatement, IEquatable<IndexDefinition> {
        protected Identifier name;
        protected bool unique = false;
        protected IndexType indexType;
        protected IReadOnlyList<IndexOption> indexOptions;
        protected IReadOnlyList<ColumnWithSortOrder> columns;
        protected IReadOnlyList<ColumnReferenceExpression> includeColumns;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        protected BooleanExpression filterPredicate;
        protected IdentifierOrValueExpression fileStreamOn;
    
        public Identifier Name => name;
        public bool Unique => unique;
        public IndexType IndexType => indexType;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public IReadOnlyList<ColumnReferenceExpression> IncludeColumns => includeColumns;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
        public BooleanExpression FilterPredicate => filterPredicate;
        public IdentifierOrValueExpression FileStreamOn => fileStreamOn;
    
        public IndexDefinition(Identifier name = null, bool unique = false, IndexType indexType = null, IReadOnlyList<IndexOption> indexOptions = null, IReadOnlyList<ColumnWithSortOrder> columns = null, IReadOnlyList<ColumnReferenceExpression> includeColumns = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, BooleanExpression filterPredicate = null, IdentifierOrValueExpression fileStreamOn = null) {
            this.name = name;
            this.unique = unique;
            this.indexType = indexType;
            this.indexOptions = indexOptions.ToImmArray<IndexOption>();
            this.columns = columns.ToImmArray<ColumnWithSortOrder>();
            this.includeColumns = includeColumns.ToImmArray<ColumnReferenceExpression>();
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.filterPredicate = filterPredicate;
            this.fileStreamOn = fileStreamOn;
        }
    
        public ScriptDom.IndexDefinition ToMutableConcrete() {
            var ret = new ScriptDom.IndexDefinition();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Unique = unique;
            ret.IndexType = (ScriptDom.IndexType)indexType?.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c?.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnWithSortOrder)c?.ToMutable()));
            ret.IncludeColumns.AddRange(includeColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme?.ToMutable();
            ret.FilterPredicate = (ScriptDom.BooleanExpression)filterPredicate?.ToMutable();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn?.ToMutable();
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
            h = h * 23 + unique.GetHashCode();
            if (!(indexType is null)) {
                h = h * 23 + indexType.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + includeColumns.GetHashCode();
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            if (!(filterPredicate is null)) {
                h = h * 23 + filterPredicate.GetHashCode();
            }
            if (!(fileStreamOn is null)) {
                h = h * 23 + fileStreamOn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexDefinition);
        } 
        
        public bool Equals(IndexDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Unique, unique)) {
                return false;
            }
            if (!EqualityComparer<IndexType>.Default.Equals(other.IndexType, indexType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnWithSortOrder>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.IncludeColumns, includeColumns)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.FilterPredicate, filterPredicate)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.FileStreamOn, fileStreamOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexDefinition left, IndexDefinition right) {
            return EqualityComparer<IndexDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexDefinition left, IndexDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IndexDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unique, othr.unique);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexType, othr.indexType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.includeColumns, othr.includeColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroupOrPartitionScheme, othr.onFileGroupOrPartitionScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.filterPredicate, othr.filterPredicate);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileStreamOn, othr.fileStreamOn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (IndexDefinition left, IndexDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IndexDefinition left, IndexDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IndexDefinition left, IndexDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IndexDefinition left, IndexDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static IndexDefinition FromMutable(ScriptDom.IndexDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.IndexDefinition)) { throw new NotImplementedException("Unexpected subtype of IndexDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IndexDefinition(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                unique: fragment.Unique,
                indexType: ImmutableDom.IndexType.FromMutable(fragment.IndexType),
                indexOptions: fragment.IndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable),
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnWithSortOrder.FromMutable),
                includeColumns: fragment.IncludeColumns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                onFileGroupOrPartitionScheme: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OnFileGroupOrPartitionScheme),
                filterPredicate: ImmutableDom.BooleanExpression.FromMutable(fragment.FilterPredicate),
                fileStreamOn: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.FileStreamOn)
            );
        }
    
    }

}
