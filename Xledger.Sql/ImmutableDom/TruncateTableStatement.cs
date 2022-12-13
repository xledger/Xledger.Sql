using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TruncateTableStatement : TSqlStatement, IEquatable<TruncateTableStatement> {
        protected SchemaObjectName tableName;
        protected IReadOnlyList<CompressionPartitionRange> partitionRanges;
    
        public SchemaObjectName TableName => tableName;
        public IReadOnlyList<CompressionPartitionRange> PartitionRanges => partitionRanges;
    
        public TruncateTableStatement(SchemaObjectName tableName = null, IReadOnlyList<CompressionPartitionRange> partitionRanges = null) {
            this.tableName = tableName;
            this.partitionRanges = partitionRanges is null ? ImmList<CompressionPartitionRange>.Empty : ImmList<CompressionPartitionRange>.FromList(partitionRanges);
        }
    
        public ScriptDom.TruncateTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.TruncateTableStatement();
            ret.TableName = (ScriptDom.SchemaObjectName)tableName.ToMutable();
            ret.PartitionRanges.AddRange(partitionRanges.SelectList(c => (ScriptDom.CompressionPartitionRange)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            h = h * 23 + partitionRanges.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TruncateTableStatement);
        } 
        
        public bool Equals(TruncateTableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CompressionPartitionRange>>.Default.Equals(other.PartitionRanges, partitionRanges)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TruncateTableStatement left, TruncateTableStatement right) {
            return EqualityComparer<TruncateTableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TruncateTableStatement left, TruncateTableStatement right) {
            return !(left == right);
        }
    
        public static TruncateTableStatement FromMutable(ScriptDom.TruncateTableStatement fragment) {
            return (TruncateTableStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
