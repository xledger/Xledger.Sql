using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewDistributionOption : ViewOption, IEquatable<ViewDistributionOption> {
        protected ViewDistributionPolicy @value;
    
        public ViewDistributionPolicy Value => @value;
    
        public ViewDistributionOption(ViewDistributionPolicy @value = null, ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ViewDistributionOption ToMutableConcrete() {
            var ret = new ScriptDom.ViewDistributionOption();
            ret.Value = (ScriptDom.ViewDistributionPolicy)@value?.ToMutable();
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
            return Equals(obj as ViewDistributionOption);
        } 
        
        public bool Equals(ViewDistributionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ViewDistributionPolicy>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ViewOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ViewDistributionOption left, ViewDistributionOption right) {
            return EqualityComparer<ViewDistributionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewDistributionOption left, ViewDistributionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ViewDistributionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ViewDistributionOption left, ViewDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ViewDistributionOption left, ViewDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ViewDistributionOption left, ViewDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ViewDistributionOption left, ViewDistributionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ViewDistributionOption FromMutable(ScriptDom.ViewDistributionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ViewDistributionOption)) { throw new NotImplementedException("Unexpected subtype of ViewDistributionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ViewDistributionOption(
                @value: ImmutableDom.ViewDistributionPolicy.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
