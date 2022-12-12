using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResampleStatisticsOption : StatisticsOption, IEquatable<ResampleStatisticsOption> {
        IReadOnlyList<StatisticsPartitionRange> partitions;
    
        public IReadOnlyList<StatisticsPartitionRange> Partitions => partitions;
    
        public ResampleStatisticsOption(IReadOnlyList<StatisticsPartitionRange> partitions = null, ScriptDom.StatisticsOptionKind optionKind = ScriptDom.StatisticsOptionKind.FullScan) {
            this.partitions = partitions is null ? ImmList<StatisticsPartitionRange>.Empty : ImmList<StatisticsPartitionRange>.FromList(partitions);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ResampleStatisticsOption ToMutableConcrete() {
            var ret = new ScriptDom.ResampleStatisticsOption();
            ret.Partitions.AddRange(partitions.Select(c => (ScriptDom.StatisticsPartitionRange)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + partitions.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResampleStatisticsOption);
        } 
        
        public bool Equals(ResampleStatisticsOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<StatisticsPartitionRange>>.Default.Equals(other.Partitions, partitions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.StatisticsOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResampleStatisticsOption left, ResampleStatisticsOption right) {
            return EqualityComparer<ResampleStatisticsOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResampleStatisticsOption left, ResampleStatisticsOption right) {
            return !(left == right);
        }
    
    }

}
