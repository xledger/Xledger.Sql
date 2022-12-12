using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexDefinition : TSqlStatement, IEquatable<IndexDefinition> {
        Identifier name;
        bool unique = false;
        IndexType indexType;
        IReadOnlyList<IndexOption> indexOptions;
        IReadOnlyList<ColumnWithSortOrder> columns;
        IReadOnlyList<ColumnReferenceExpression> includeColumns;
        FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        BooleanExpression filterPredicate;
        IdentifierOrValueExpression fileStreamOn;
    
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
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
            this.columns = columns is null ? ImmList<ColumnWithSortOrder>.Empty : ImmList<ColumnWithSortOrder>.FromList(columns);
            this.includeColumns = includeColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(includeColumns);
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.filterPredicate = filterPredicate;
            this.fileStreamOn = fileStreamOn;
        }
    
        public ScriptDom.IndexDefinition ToMutableConcrete() {
            var ret = new ScriptDom.IndexDefinition();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Unique = unique;
            ret.IndexType = (ScriptDom.IndexType)indexType.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnWithSortOrder)c.ToMutable()));
            ret.IncludeColumns.AddRange(includeColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme.ToMutable();
            ret.FilterPredicate = (ScriptDom.BooleanExpression)filterPredicate.ToMutable();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn.ToMutable();
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
    
    }

}
