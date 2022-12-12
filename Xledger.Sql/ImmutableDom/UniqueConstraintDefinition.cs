using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UniqueConstraintDefinition : ConstraintDefinition, IEquatable<UniqueConstraintDefinition> {
        protected bool? clustered;
        protected bool isPrimaryKey = false;
        protected bool? isEnforced;
        protected IReadOnlyList<ColumnWithSortOrder> columns;
        protected IReadOnlyList<IndexOption> indexOptions;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        protected IndexType indexType;
        protected IdentifierOrValueExpression fileStreamOn;
    
        public bool? Clustered => clustered;
        public bool IsPrimaryKey => isPrimaryKey;
        public bool? IsEnforced => isEnforced;
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
        public IndexType IndexType => indexType;
        public IdentifierOrValueExpression FileStreamOn => fileStreamOn;
    
        public UniqueConstraintDefinition(bool? clustered = null, bool isPrimaryKey = false, bool? isEnforced = null, IReadOnlyList<ColumnWithSortOrder> columns = null, IReadOnlyList<IndexOption> indexOptions = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, IndexType indexType = null, IdentifierOrValueExpression fileStreamOn = null, Identifier constraintIdentifier = null) {
            this.clustered = clustered;
            this.isPrimaryKey = isPrimaryKey;
            this.isEnforced = isEnforced;
            this.columns = columns is null ? ImmList<ColumnWithSortOrder>.Empty : ImmList<ColumnWithSortOrder>.FromList(columns);
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.indexType = indexType;
            this.fileStreamOn = fileStreamOn;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.UniqueConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.UniqueConstraintDefinition();
            ret.Clustered = clustered;
            ret.IsPrimaryKey = isPrimaryKey;
            ret.IsEnforced = isEnforced;
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnWithSortOrder)c.ToMutable()));
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme.ToMutable();
            ret.IndexType = (ScriptDom.IndexType)indexType.ToMutable();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn.ToMutable();
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + clustered.GetHashCode();
            h = h * 23 + isPrimaryKey.GetHashCode();
            h = h * 23 + isEnforced.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + indexOptions.GetHashCode();
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            if (!(indexType is null)) {
                h = h * 23 + indexType.GetHashCode();
            }
            if (!(fileStreamOn is null)) {
                h = h * 23 + fileStreamOn.GetHashCode();
            }
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UniqueConstraintDefinition);
        } 
        
        public bool Equals(UniqueConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool?>.Default.Equals(other.Clustered, clustered)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsPrimaryKey, isPrimaryKey)) {
                return false;
            }
            if (!EqualityComparer<bool?>.Default.Equals(other.IsEnforced, isEnforced)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnWithSortOrder>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<IndexType>.Default.Equals(other.IndexType, indexType)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.FileStreamOn, fileStreamOn)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UniqueConstraintDefinition left, UniqueConstraintDefinition right) {
            return EqualityComparer<UniqueConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UniqueConstraintDefinition left, UniqueConstraintDefinition right) {
            return !(left == right);
        }
    
    }

}
