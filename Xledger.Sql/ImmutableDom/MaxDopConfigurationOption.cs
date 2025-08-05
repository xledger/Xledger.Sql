using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxDopConfigurationOption : DatabaseConfigurationSetOption, IEquatable<MaxDopConfigurationOption> {
        protected Literal @value;
        protected bool primary = false;
    
        public Literal Value => @value;
        public bool Primary => primary;
    
        public MaxDopConfigurationOption(Literal @value = null, bool primary = false, ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.@value = @value;
            this.primary = primary;
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public new ScriptDom.MaxDopConfigurationOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxDopConfigurationOption();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
            ret.Primary = primary;
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind?.ToMutable();
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
            h = h * 23 + primary.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxDopConfigurationOption);
        } 
        
        public bool Equals(MaxDopConfigurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Primary, primary)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseConfigSetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GenericOptionKind, genericOptionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxDopConfigurationOption left, MaxDopConfigurationOption right) {
            return EqualityComparer<MaxDopConfigurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxDopConfigurationOption left, MaxDopConfigurationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxDopConfigurationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.primary, othr.primary);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.genericOptionKind, othr.genericOptionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MaxDopConfigurationOption left, MaxDopConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxDopConfigurationOption left, MaxDopConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxDopConfigurationOption left, MaxDopConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxDopConfigurationOption left, MaxDopConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MaxDopConfigurationOption FromMutable(ScriptDom.MaxDopConfigurationOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MaxDopConfigurationOption)) { throw new NotImplementedException("Unexpected subtype of MaxDopConfigurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxDopConfigurationOption(
                @value: ImmutableDom.Literal.FromMutable(fragment.Value),
                primary: fragment.Primary,
                optionKind: fragment.OptionKind,
                genericOptionKind: ImmutableDom.Identifier.FromMutable(fragment.GenericOptionKind)
            );
        }
    
    }

}
