using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationStatement : TSqlStatement, IEquatable<AlterServerConfigurationStatement> {
        ScriptDom.ProcessAffinityType processAffinity = ScriptDom.ProcessAffinityType.CpuAuto;
        IReadOnlyList<ProcessAffinityRange> processAffinityRanges;
    
        public ScriptDom.ProcessAffinityType ProcessAffinity => processAffinity;
        public IReadOnlyList<ProcessAffinityRange> ProcessAffinityRanges => processAffinityRanges;
    
        public AlterServerConfigurationStatement(ScriptDom.ProcessAffinityType processAffinity = ScriptDom.ProcessAffinityType.CpuAuto, IReadOnlyList<ProcessAffinityRange> processAffinityRanges = null) {
            this.processAffinity = processAffinity;
            this.processAffinityRanges = processAffinityRanges is null ? ImmList<ProcessAffinityRange>.Empty : ImmList<ProcessAffinityRange>.FromList(processAffinityRanges);
        }
    
        public ScriptDom.AlterServerConfigurationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationStatement();
            ret.ProcessAffinity = processAffinity;
            ret.ProcessAffinityRanges.AddRange(processAffinityRanges.Select(c => (ScriptDom.ProcessAffinityRange)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + processAffinity.GetHashCode();
            h = h * 23 + processAffinityRanges.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationStatement);
        } 
        
        public bool Equals(AlterServerConfigurationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ProcessAffinityType>.Default.Equals(other.ProcessAffinity, processAffinity)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcessAffinityRange>>.Default.Equals(other.ProcessAffinityRanges, processAffinityRanges)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) {
            return EqualityComparer<AlterServerConfigurationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) {
            return !(left == right);
        }
    
    }

}
