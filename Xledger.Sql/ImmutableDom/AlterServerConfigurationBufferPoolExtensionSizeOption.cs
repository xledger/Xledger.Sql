using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationBufferPoolExtensionSizeOption : AlterServerConfigurationBufferPoolExtensionOption, IEquatable<AlterServerConfigurationBufferPoolExtensionSizeOption> {
        protected ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified;
    
        public ScriptDom.MemoryUnit SizeUnit => sizeUnit;
    
        public AlterServerConfigurationBufferPoolExtensionSizeOption(ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified, ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind optionKind = ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind.None, OptionValue optionValue = null) {
            this.sizeUnit = sizeUnit;
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public new ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption();
            ret.SizeUnit = sizeUnit;
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sizeUnit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationBufferPoolExtensionSizeOption);
        } 
        
        public bool Equals(AlterServerConfigurationBufferPoolExtensionSizeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.SizeUnit, sizeUnit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) {
            return EqualityComparer<AlterServerConfigurationBufferPoolExtensionSizeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationBufferPoolExtensionSizeOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.sizeUnit, othr.sizeUnit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationBufferPoolExtensionSizeOption left, AlterServerConfigurationBufferPoolExtensionSizeOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterServerConfigurationBufferPoolExtensionSizeOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption)) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationBufferPoolExtensionSizeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationBufferPoolExtensionSizeOption(
                sizeUnit: fragment.SizeUnit,
                optionKind: fragment.OptionKind,
                optionValue: ImmutableDom.OptionValue.FromMutable(fragment.OptionValue)
            );
        }
    
    }

}
