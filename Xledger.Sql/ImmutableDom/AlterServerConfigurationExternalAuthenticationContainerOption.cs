using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationExternalAuthenticationContainerOption : AlterServerConfigurationExternalAuthenticationOption, IEquatable<AlterServerConfigurationExternalAuthenticationContainerOption> {
        protected IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> suboptions;
    
        public IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> Suboptions => suboptions;
    
        public AlterServerConfigurationExternalAuthenticationContainerOption(IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> suboptions = null, ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind optionKind = ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind.None, OptionValue optionValue = null) {
            this.suboptions = ImmList<AlterServerConfigurationExternalAuthenticationOption>.FromList(suboptions);
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption();
            ret.Suboptions.AddRange(suboptions.SelectList(c => (ScriptDom.AlterServerConfigurationExternalAuthenticationOption)c?.ToMutable()));
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue?.ToMutable();
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
            return Equals(obj as AlterServerConfigurationExternalAuthenticationContainerOption);
        } 
        
        public bool Equals(AlterServerConfigurationExternalAuthenticationContainerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption>>.Default.Equals(other.Suboptions, suboptions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) {
            return EqualityComparer<AlterServerConfigurationExternalAuthenticationContainerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationExternalAuthenticationContainerOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.suboptions, othr.suboptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationExternalAuthenticationContainerOption left, AlterServerConfigurationExternalAuthenticationContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
