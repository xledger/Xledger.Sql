using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableRebuildStatement : AlterTableStatement, IEquatable<AlterTableRebuildStatement> {
        protected PartitionSpecifier partition;
        protected IReadOnlyList<IndexOption> indexOptions;
    
        public PartitionSpecifier Partition => partition;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
    
        public AlterTableRebuildStatement(PartitionSpecifier partition = null, IReadOnlyList<IndexOption> indexOptions = null, SchemaObjectName schemaObjectName = null) {
            this.partition = partition;
            this.indexOptions = ImmList<IndexOption>.FromList(indexOptions);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableRebuildStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableRebuildStatement();
            ret.Partition = (ScriptDom.PartitionSpecifier)partition.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(partition is null)) {
                h = h * 23 + partition.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableRebuildStatement);
        } 
        
        public bool Equals(AlterTableRebuildStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<PartitionSpecifier>.Default.Equals(other.Partition, partition)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableRebuildStatement left, AlterTableRebuildStatement right) {
            return EqualityComparer<AlterTableRebuildStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableRebuildStatement left, AlterTableRebuildStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableRebuildStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.partition, othr.partition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterTableRebuildStatement left, AlterTableRebuildStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableRebuildStatement left, AlterTableRebuildStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableRebuildStatement left, AlterTableRebuildStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableRebuildStatement left, AlterTableRebuildStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableRebuildStatement FromMutable(ScriptDom.AlterTableRebuildStatement fragment) {
            return (AlterTableRebuildStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
