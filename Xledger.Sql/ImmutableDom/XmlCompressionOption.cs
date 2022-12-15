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
            this.partitionRanges = ImmList<CompressionPartitionRange>.FromList(partitionRanges);
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (XmlCompressionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isCompressed, othr.isCompressed);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.partitionRanges, othr.partitionRanges);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (XmlCompressionOption left, XmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(XmlCompressionOption left, XmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (XmlCompressionOption left, XmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(XmlCompressionOption left, XmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
