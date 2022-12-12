using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationFailoverClusterPropertyOption : TSqlFragment, IEquatable<AlterServerConfigurationFailoverClusterPropertyOption> {
        protected ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind optionKind = ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind.None;
        protected OptionValue optionValue;
    
        public ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
    
        public AlterServerConfigurationFailoverClusterPropertyOption(ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind optionKind = ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind.None, OptionValue optionValue = null) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption();
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
            return Equals(obj as AlterServerConfigurationFailoverClusterPropertyOption);
        } 
        
        public bool Equals(AlterServerConfigurationFailoverClusterPropertyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationFailoverClusterPropertyOption left, AlterServerConfigurationFailoverClusterPropertyOption right) {
            return EqualityComparer<AlterServerConfigurationFailoverClusterPropertyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationFailoverClusterPropertyOption left, AlterServerConfigurationFailoverClusterPropertyOption right) {
            return !(left == right);
        }
    
    }

}
