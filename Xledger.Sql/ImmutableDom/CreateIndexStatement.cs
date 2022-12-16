using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateIndexStatement : IndexStatement, IEquatable<CreateIndexStatement> {
        protected bool translated80SyntaxTo90 = false;
        protected bool unique = false;
        protected bool? clustered;
        protected IReadOnlyList<ColumnWithSortOrder> columns;
        protected IReadOnlyList<ColumnReferenceExpression> includeColumns;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        protected BooleanExpression filterPredicate;
        protected IdentifierOrValueExpression fileStreamOn;
    
        public bool Translated80SyntaxTo90 => translated80SyntaxTo90;
        public bool Unique => unique;
        public bool? Clustered => clustered;
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public IReadOnlyList<ColumnReferenceExpression> IncludeColumns => includeColumns;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
        public BooleanExpression FilterPredicate => filterPredicate;
        public IdentifierOrValueExpression FileStreamOn => fileStreamOn;
    
        public CreateIndexStatement(bool translated80SyntaxTo90 = false, bool unique = false, bool? clustered = null, IReadOnlyList<ColumnWithSortOrder> columns = null, IReadOnlyList<ColumnReferenceExpression> includeColumns = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, BooleanExpression filterPredicate = null, IdentifierOrValueExpression fileStreamOn = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.translated80SyntaxTo90 = translated80SyntaxTo90;
            this.unique = unique;
            this.clustered = clustered;
            this.columns = ImmList<ColumnWithSortOrder>.FromList(columns);
            this.includeColumns = ImmList<ColumnReferenceExpression>.FromList(includeColumns);
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.filterPredicate = filterPredicate;
            this.fileStreamOn = fileStreamOn;
            this.name = name;
            this.onName = onName;
            this.indexOptions = ImmList<IndexOption>.FromList(indexOptions);
        }
    
        public ScriptDom.CreateIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateIndexStatement();
            ret.Translated80SyntaxTo90 = translated80SyntaxTo90;
            ret.Unique = unique;
            ret.Clustered = clustered;
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnWithSortOrder)c?.ToMutable()));
            ret.IncludeColumns.AddRange(includeColumns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme?.ToMutable();
            ret.FilterPredicate = (ScriptDom.BooleanExpression)filterPredicate?.ToMutable();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName?.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + translated80SyntaxTo90.GetHashCode();
            h = h * 23 + unique.GetHashCode();
            h = h * 23 + clustered.GetHashCode();
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
            return Equals(obj as CreateIndexStatement);
        } 
        
        public bool Equals(CreateIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Translated80SyntaxTo90, translated80SyntaxTo90)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Unique, unique)) {
                return false;
            }
            if (!EqualityComparer<bool?>.Default.Equals(other.Clustered, clustered)) {
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
        
        public static bool operator ==(CreateIndexStatement left, CreateIndexStatement right) {
            return EqualityComparer<CreateIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateIndexStatement left, CreateIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.translated80SyntaxTo90, othr.translated80SyntaxTo90);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unique, othr.unique);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.clustered, othr.clustered);
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
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateIndexStatement left, CreateIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateIndexStatement left, CreateIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateIndexStatement left, CreateIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateIndexStatement left, CreateIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
