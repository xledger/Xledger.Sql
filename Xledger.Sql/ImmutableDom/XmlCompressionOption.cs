using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlCompressionOption : IndexOption, IEquatable<XmlCompressionOption> {
        protected ScriptDom.XmlCompressionOptionState isCompressed = ScriptDom.XmlCompressionOptionState.Off;
        protected IReadOnlyList<CompressionPartitionRange> partitionRanges;
    
        public ScriptDom.XmlCompressionOptionState IsCompressed => isCompressed;
        public IReadOnlyList<CompressionPartitionRange> PartitionRanges => partitionRanges;
    
        public XmlCompressionOption(ScriptDom.XmlCompressionOptionState isCompressed = ScriptDom.XmlCompressionOptionState.Off, IReadOnlyList<CompressionPartitionRange> partitionRanges = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.isCompressed = isCompressed;
            this.partitionRanges = partitionRanges is null ? ImmList<CompressionPartitionRange>.Empty : ImmList<CompressionPartitionRange>.FromList(partitionRanges);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.XmlCompressionOption ToMutableConcrete() {
            var ret = new ScriptDom.XmlCompressionOption();
            ret.IsCompressed = isCompressed;
            ret.PartitionRanges.AddRange(partitionRanges.SelectList(c => (ScriptDom.CompressionPartitionRange)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isCompressed.GetHashCode();
            h = h * 23 + partitionRanges.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlCompressionOption);
        } 
        
        public bool Equals(XmlCompressionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.XmlCompressionOptionState>.Default.Equals(other.IsCompressed, isCompressed)) {
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
        
        public static bool operator ==(XmlCompressionOption left, XmlCompressionOption right) {
            return EqualityComparer<XmlCompressionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlCompressionOption left, XmlCompressionOption right) {
            return !(left == right);
        }
    
    }

}
