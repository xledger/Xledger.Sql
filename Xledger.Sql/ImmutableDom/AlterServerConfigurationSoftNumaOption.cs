using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSoftNumaOption : TSqlFragment, IEquatable<AlterServerConfigurationSoftNumaOption> {
        protected ScriptDom.AlterServerConfigurationSoftNumaOptionKind optionKind = ScriptDom.AlterServerConfigurationSoftNumaOptionKind.None;
        protected OptionValue optionValue;
    
        public ScriptDom.AlterServerConfigurationSoftNumaOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
    
        public AlterServerConfigurationSoftNumaOption(ScriptDom.AlterServerConfigurationSoftNumaOptionKind optionKind = ScriptDom.AlterServerConfigurationSoftNumaOptionKind.None, OptionValue optionValue = null) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationSoftNumaOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSoftNumaOption();
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue.ToMutable();
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
            return Equals(obj as AlterServerConfigurationSoftNumaOption);
        } 
        
        public bool Equals(AlterServerConfigurationSoftNumaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationSoftNumaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSoftNumaOption left, AlterServerConfigurationSoftNumaOption right) {
            return EqualityComparer<AlterServerConfigurationSoftNumaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSoftNumaOption left, AlterServerConfigurationSoftNumaOption right) {
            return !(left == right);
        }
    
    }

}
