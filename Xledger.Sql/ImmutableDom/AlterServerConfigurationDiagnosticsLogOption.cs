using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationDiagnosticsLogOption : TSqlFragment, IEquatable<AlterServerConfigurationDiagnosticsLogOption> {
        protected ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind optionKind = ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind.None;
        protected OptionValue optionValue;
    
        public ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
    
        public AlterServerConfigurationDiagnosticsLogOption(ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind optionKind = ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind.None, OptionValue optionValue = null) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationDiagnosticsLogOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationDiagnosticsLogOption();
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationDiagnosticsLogOption);
        } 
        
        public bool Equals(AlterServerConfigurationDiagnosticsLogOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) {
            return EqualityComparer<AlterServerConfigurationDiagnosticsLogOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationDiagnosticsLogOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationDiagnosticsLogOption left, AlterServerConfigurationDiagnosticsLogOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
