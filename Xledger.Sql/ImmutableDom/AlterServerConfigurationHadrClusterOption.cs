using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationHadrClusterOption : TSqlFragment, IEquatable<AlterServerConfigurationHadrClusterOption> {
        protected ScriptDom.AlterServerConfigurationHadrClusterOptionKind optionKind = ScriptDom.AlterServerConfigurationHadrClusterOptionKind.None;
        protected OptionValue optionValue;
        protected bool isLocal = false;
    
        public ScriptDom.AlterServerConfigurationHadrClusterOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
        public bool IsLocal => isLocal;
    
        public AlterServerConfigurationHadrClusterOption(ScriptDom.AlterServerConfigurationHadrClusterOptionKind optionKind = ScriptDom.AlterServerConfigurationHadrClusterOptionKind.None, OptionValue optionValue = null, bool isLocal = false) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
            this.isLocal = isLocal;
        }
    
        public ScriptDom.AlterServerConfigurationHadrClusterOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationHadrClusterOption();
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue?.ToMutable();
            ret.IsLocal = isLocal;
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
            h = h * 23 + isLocal.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationHadrClusterOption);
        } 
        
        public bool Equals(AlterServerConfigurationHadrClusterOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationHadrClusterOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsLocal, isLocal)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) {
            return EqualityComparer<AlterServerConfigurationHadrClusterOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationHadrClusterOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isLocal, othr.isLocal);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationHadrClusterOption left, AlterServerConfigurationHadrClusterOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
