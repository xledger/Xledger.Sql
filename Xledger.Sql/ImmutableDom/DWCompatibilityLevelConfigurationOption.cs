using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DWCompatibilityLevelConfigurationOption : DatabaseConfigurationSetOption, IEquatable<DWCompatibilityLevelConfigurationOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public DWCompatibilityLevelConfigurationOption(Literal @value = null, ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.@value = @value;
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public new ScriptDom.DWCompatibilityLevelConfigurationOption ToMutableConcrete() {
            var ret = new ScriptDom.DWCompatibilityLevelConfigurationOption();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
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
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DWCompatibilityLevelConfigurationOption);
        } 
        
        public bool Equals(DWCompatibilityLevelConfigurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
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
        
        public static bool operator ==(DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) {
            return EqualityComparer<DWCompatibilityLevelConfigurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DWCompatibilityLevelConfigurationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.genericOptionKind, othr.genericOptionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DWCompatibilityLevelConfigurationOption left, DWCompatibilityLevelConfigurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DWCompatibilityLevelConfigurationOption FromMutable(ScriptDom.DWCompatibilityLevelConfigurationOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DWCompatibilityLevelConfigurationOption)) { throw new NotImplementedException("Unexpected subtype of DWCompatibilityLevelConfigurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DWCompatibilityLevelConfigurationOption(
                @value: ImmutableDom.Literal.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind,
                genericOptionKind: ImmutableDom.Identifier.FromMutable(fragment.GenericOptionKind)
            );
        }
    
    }

}
