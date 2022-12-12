using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileGroupOrPartitionScheme : TSqlFragment, IEquatable<FileGroupOrPartitionScheme> {
        protected IdentifierOrValueExpression name;
        protected IReadOnlyList<Identifier> partitionSchemeColumns;
    
        public IdentifierOrValueExpression Name => name;
        public IReadOnlyList<Identifier> PartitionSchemeColumns => partitionSchemeColumns;
    
        public FileGroupOrPartitionScheme(IdentifierOrValueExpression name = null, IReadOnlyList<Identifier> partitionSchemeColumns = null) {
            this.name = name;
            this.partitionSchemeColumns = partitionSchemeColumns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(partitionSchemeColumns);
        }
    
        public ScriptDom.FileGroupOrPartitionScheme ToMutableConcrete() {
            var ret = new ScriptDom.FileGroupOrPartitionScheme();
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name.ToMutable();
            ret.PartitionSchemeColumns.AddRange(partitionSchemeColumns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
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
            h = h * 23 + partitionSchemeColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileGroupOrPartitionScheme);
        } 
        
        public bool Equals(FileGroupOrPartitionScheme other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.PartitionSchemeColumns, partitionSchemeColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileGroupOrPartitionScheme left, FileGroupOrPartitionScheme right) {
            return EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileGroupOrPartitionScheme left, FileGroupOrPartitionScheme right) {
            return !(left == right);
        }
    
    }

}
