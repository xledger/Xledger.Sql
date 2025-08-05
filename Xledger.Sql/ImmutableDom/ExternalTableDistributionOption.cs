using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableDistributionOption : ExternalTableOption, IEquatable<ExternalTableDistributionOption> {
        protected ExternalTableDistributionPolicy @value;
    
        public ExternalTableDistributionPolicy Value => @value;
    
        public ExternalTableDistributionOption(ExternalTableDistributionPolicy @value = null, ScriptDom.ExternalTableOptionKind optionKind = ScriptDom.ExternalTableOptionKind.Distribution) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalTableDistributionOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableDistributionOption();
            ret.Value = (ScriptDom.ExternalTableDistributionPolicy)@value?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalTableDistributionOption);
        } 
        
        public bool Equals(ExternalTableDistributionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExternalTableDistributionPolicy>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalTableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableDistributionOption left, ExternalTableDistributionOption right) {
            return EqualityComparer<ExternalTableDistributionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableDistributionOption left, ExternalTableDistributionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalTableDistributionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalTableDistributionOption left, ExternalTableDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalTableDistributionOption left, ExternalTableDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalTableDistributionOption left, ExternalTableDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalTableDistributionOption left, ExternalTableDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalTableDistributionOption FromMutable(ScriptDom.ExternalTableDistributionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalTableDistributionOption)) { throw new NotImplementedException("Unexpected subtype of ExternalTableDistributionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableDistributionOption(
                @value: ImmutableDom.ExternalTableDistributionPolicy.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
