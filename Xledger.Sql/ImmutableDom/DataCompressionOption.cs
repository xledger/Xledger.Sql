using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DataCompressionOption : IndexOption, IEquatable<DataCompressionOption> {
        protected ScriptDom.DataCompressionLevel compressionLevel = ScriptDom.DataCompressionLevel.None;
        protected IReadOnlyList<CompressionPartitionRange> partitionRanges;
    
        public ScriptDom.DataCompressionLevel CompressionLevel => compressionLevel;
        public IReadOnlyList<CompressionPartitionRange> PartitionRanges => partitionRanges;
    
        public DataCompressionOption(ScriptDom.DataCompressionLevel compressionLevel = ScriptDom.DataCompressionLevel.None, IReadOnlyList<CompressionPartitionRange> partitionRanges = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.compressionLevel = compressionLevel;
            this.partitionRanges = partitionRanges is null ? ImmList<CompressionPartitionRange>.Empty : ImmList<CompressionPartitionRange>.FromList(partitionRanges);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DataCompressionOption ToMutableConcrete() {
            var ret = new ScriptDom.DataCompressionOption();
            ret.CompressionLevel = compressionLevel;
            ret.PartitionRanges.AddRange(partitionRanges.SelectList(c => (ScriptDom.CompressionPartitionRange)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + compressionLevel.GetHashCode();
            h = h * 23 + partitionRanges.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DataCompressionOption);
        } 
        
        public bool Equals(DataCompressionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DataCompressionLevel>.Default.Equals(other.CompressionLevel, compressionLevel)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CompressionPartitionRange>>.Default.Equals(other.PartitionRanges, partitionRanges)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DataCompressionOption left, DataCompressionOption right) {
            return EqualityComparer<DataCompressionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DataCompressionOption left, DataCompressionOption right) {
            return !(left == right);
        }
    
        public static DataCompressionOption FromMutable(ScriptDom.DataCompressionOption fragment) {
            return (DataCompressionOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
