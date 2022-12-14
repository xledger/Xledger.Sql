using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationExternalAuthenticationOption : TSqlFragment, IEquatable<AlterServerConfigurationExternalAuthenticationOption> {
        protected ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind optionKind = ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind.None;
        protected OptionValue optionValue;
    
        public ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind OptionKind => optionKind;
        public OptionValue OptionValue => optionValue;
    
        public AlterServerConfigurationExternalAuthenticationOption(ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind optionKind = ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind.None, OptionValue optionValue = null) {
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationExternalAuthenticationOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationExternalAuthenticationOption();
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
            return Equals(obj as AlterServerConfigurationExternalAuthenticationOption);
        } 
        
        public bool Equals(AlterServerConfigurationExternalAuthenticationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationExternalAuthenticationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationExternalAuthenticationOption left, AlterServerConfigurationExternalAuthenticationOption right) {
            return EqualityComparer<AlterServerConfigurationExternalAuthenticationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationExternalAuthenticationOption left, AlterServerConfigurationExternalAuthenticationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationExternalAuthenticationOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterServerConfigurationExternalAuthenticationOption FromMutable(ScriptDom.AlterServerConfigurationExternalAuthenticationOption fragment) {
            return (AlterServerConfigurationExternalAuthenticationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
