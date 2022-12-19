using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationStatement : TSqlStatement, IEquatable<AlterServerConfigurationStatement> {
        protected ScriptDom.ProcessAffinityType processAffinity = ScriptDom.ProcessAffinityType.CpuAuto;
        protected IReadOnlyList<ProcessAffinityRange> processAffinityRanges;
    
        public ScriptDom.ProcessAffinityType ProcessAffinity => processAffinity;
        public IReadOnlyList<ProcessAffinityRange> ProcessAffinityRanges => processAffinityRanges;
    
        public AlterServerConfigurationStatement(ScriptDom.ProcessAffinityType processAffinity = ScriptDom.ProcessAffinityType.CpuAuto, IReadOnlyList<ProcessAffinityRange> processAffinityRanges = null) {
            this.processAffinity = processAffinity;
            this.processAffinityRanges = ImmList<ProcessAffinityRange>.FromList(processAffinityRanges);
        }
    
        public ScriptDom.AlterServerConfigurationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationStatement();
            ret.ProcessAffinity = processAffinity;
            ret.ProcessAffinityRanges.AddRange(processAffinityRanges.SelectList(c => (ScriptDom.ProcessAffinityRange)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.processAffinity, othr.processAffinity);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.processAffinityRanges, othr.processAffinityRanges);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationStatement left, AlterServerConfigurationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterServerConfigurationStatement FromMutable(ScriptDom.AlterServerConfigurationStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterServerConfigurationStatement)) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationStatement(
                processAffinity: fragment.ProcessAffinity,
                processAffinityRanges: fragment.ProcessAffinityRanges.SelectList(ImmutableDom.ProcessAffinityRange.FromMutable)
            );
        }
    
    }

}
