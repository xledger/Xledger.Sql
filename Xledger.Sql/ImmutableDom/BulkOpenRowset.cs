using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BulkOpenRowset : TableReferenceWithAliasAndColumns, IEquatable<BulkOpenRowset> {
        protected IReadOnlyList<StringLiteral> dataFiles;
        protected IReadOnlyList<BulkInsertOption> options;
        protected IReadOnlyList<OpenRowsetColumnDefinition> withColumns;
    
        public IReadOnlyList<StringLiteral> DataFiles => dataFiles;
        public IReadOnlyList<BulkInsertOption> Options => options;
        public IReadOnlyList<OpenRowsetColumnDefinition> WithColumns => withColumns;
    
        public BulkOpenRowset(IReadOnlyList<StringLiteral> dataFiles = null, IReadOnlyList<BulkInsertOption> options = null, IReadOnlyList<OpenRowsetColumnDefinition> withColumns = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.dataFiles = dataFiles is null ? ImmList<StringLiteral>.Empty : ImmList<StringLiteral>.FromList(dataFiles);
            this.options = options is null ? ImmList<BulkInsertOption>.Empty : ImmList<BulkInsertOption>.FromList(options);
            this.withColumns = withColumns is null ? ImmList<OpenRowsetColumnDefinition>.Empty : ImmList<OpenRowsetColumnDefinition>.FromList(withColumns);
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.BulkOpenRowset ToMutableConcrete() {
            var ret = new ScriptDom.BulkOpenRowset();
            ret.DataFiles.AddRange(dataFiles.SelectList(c => (ScriptDom.StringLiteral)c.ToMutable()));
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BulkInsertOption)c.ToMutable()));
            ret.WithColumns.AddRange(withColumns.SelectList(c => (ScriptDom.OpenRowsetColumnDefinition)c.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + dataFiles.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + withColumns.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BulkOpenRowset);
        } 
        
        public bool Equals(BulkOpenRowset other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<StringLiteral>>.Default.Equals(other.DataFiles, dataFiles)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BulkInsertOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OpenRowsetColumnDefinition>>.Default.Equals(other.WithColumns, withColumns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BulkOpenRowset left, BulkOpenRowset right) {
            return EqualityComparer<BulkOpenRowset>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BulkOpenRowset left, BulkOpenRowset right) {
            return !(left == right);
        }
    
    }

}
