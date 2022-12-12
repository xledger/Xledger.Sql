using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationBufferPoolExtensionSizeOption : AlterServerConfigurationBufferPoolExtensionOption, IEquatable<AlterServerConfigurationBufferPoolExtensionSizeOption> {
        ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified;
    
        public ScriptDom.MemoryUnit SizeUnit => sizeUnit;
    
        public AlterServerConfigurationBufferPoolExtensionSizeOption(ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified, ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind optionKind = ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind.None, OptionValue optionValue = null) {
            this.sizeUnit = sizeUnit;
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption();
            ret.SizeUnit = sizeUnit;
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue.ToMutable();
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
    
    }

}
