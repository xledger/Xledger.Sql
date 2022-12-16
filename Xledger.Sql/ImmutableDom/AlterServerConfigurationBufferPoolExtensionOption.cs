using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationBufferPoolExtensionOption : TSqlFragment, IEquatable<AlterServerConfigurationBufferPoolExtensionOption> {
        protected ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind optionKind = ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind.None;
        protected OptionValue optionValue;
    
        public ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
    
        public AlterServerConfigurationBufferPoolExtensionOption(ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind optionKind = ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind.None, OptionValue optionValue = null) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationBufferPoolExtensionOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationBufferPoolExtensionOption();
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
            return Equals(obj as AlterServerConfigurationBufferPoolExtensionOption);
        } 
        
        public bool Equals(AlterServerConfigurationBufferPoolExtensionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) {
            return EqualityComparer<AlterServerConfigurationBufferPoolExtensionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationBufferPoolExtensionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationBufferPoolExtensionOption left, AlterServerConfigurationBufferPoolExtensionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
