using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            this.columns = columns.ToImmArray<ColumnWithSortOrder>();
            this.indexOptions = indexOptions.ToImmArray<IndexOption>();
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
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnWithSortOrder)c?.ToMutable()));
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c?.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme?.ToMutable();
            ret.IndexType = (ScriptDom.IndexType)indexType?.ToMutable();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn?.ToMutable();
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UniqueConstraintDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.clustered, othr.clustered);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isPrimaryKey, othr.isPrimaryKey);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isEnforced, othr.isEnforced);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroupOrPartitionScheme, othr.onFileGroupOrPartitionScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexType, othr.indexType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileStreamOn, othr.fileStreamOn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.constraintIdentifier, othr.constraintIdentifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UniqueConstraintDefinition left, UniqueConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UniqueConstraintDefinition left, UniqueConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UniqueConstraintDefinition left, UniqueConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UniqueConstraintDefinition left, UniqueConstraintDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UniqueConstraintDefinition FromMutable(ScriptDom.UniqueConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UniqueConstraintDefinition)) { throw new NotImplementedException("Unexpected subtype of UniqueConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UniqueConstraintDefinition(
                clustered: fragment.Clustered,
                isPrimaryKey: fragment.IsPrimaryKey,
                isEnforced: fragment.IsEnforced,
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnWithSortOrder.FromMutable),
                indexOptions: fragment.IndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable),
                onFileGroupOrPartitionScheme: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OnFileGroupOrPartitionScheme),
                indexType: ImmutableDom.IndexType.FromMutable(fragment.IndexType),
                fileStreamOn: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.FileStreamOn),
                constraintIdentifier: ImmutableDom.Identifier.FromMutable(fragment.ConstraintIdentifier)
            );
        }
    
    }

}
