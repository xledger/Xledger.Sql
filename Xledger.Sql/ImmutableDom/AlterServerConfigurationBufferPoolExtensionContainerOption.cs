using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationBufferPoolExtensionContainerOption : AlterServerConfigurationBufferPoolExtensionOption, IEquatable<AlterServerConfigurationBufferPoolExtensionContainerOption> {
        protected IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> suboptions;
    
        public IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> Suboptions => suboptions;
    
        public AlterServerConfigurationBufferPoolExtensionContainerOption(IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> suboptions = null, ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind optionKind = ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind.None, OptionValue optionValue = null) {
            this.suboptions = suboptions is null ? ImmList<AlterServerConfigurationBufferPoolExtensionOption>.Empty : ImmList<AlterServerConfigurationBufferPoolExtensionOption>.FromList(suboptions);
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption();
            ret.Suboptions.AddRange(suboptions.SelectList(c => (ScriptDom.AlterServerConfigurationBufferPoolExtensionOption)c.ToMutable()));
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + suboptions.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationBufferPoolExtensionContainerOption);
        } 
        
        public bool Equals(AlterServerConfigurationBufferPoolExtensionContainerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption>>.Default.Equals(other.Suboptions, suboptions)) {
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
        
        public static bool operator ==(AlterServerConfigurationBufferPoolExtensionContainerOption left, AlterServerConfigurationBufferPoolExtensionContainerOption right) {
            return EqualityComparer<AlterServerConfigurationBufferPoolExtensionContainerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationBufferPoolExtensionContainerOption left, AlterServerConfigurationBufferPoolExtensionContainerOption right) {
            return !(left == right);
        }
    
    }

}
