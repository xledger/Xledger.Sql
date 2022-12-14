using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SensitivityClassificationOption : TSqlFragment, IEquatable<SensitivityClassificationOption> {
        protected ScriptDom.SensitivityClassification.OptionType type = ScriptDom.SensitivityClassification.OptionType.Label;
        protected Literal @value;
    
        public ScriptDom.SensitivityClassification.OptionType Type => type;
        public Literal Value => @value;
    
        public SensitivityClassificationOption(ScriptDom.SensitivityClassification.OptionType type = ScriptDom.SensitivityClassification.OptionType.Label, Literal @value = null) {
            this.type = type;
            this.@value = @value;
        }
    
        public ScriptDom.SensitivityClassificationOption ToMutableConcrete() {
            var ret = new ScriptDom.SensitivityClassificationOption();
            ret.Type = type;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + type.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SensitivityClassificationOption);
        } 
        
        public bool Equals(SensitivityClassificationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SensitivityClassification.OptionType>.Default.Equals(other.Type, type)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SensitivityClassificationOption left, SensitivityClassificationOption right) {
            return EqualityComparer<SensitivityClassificationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SensitivityClassificationOption left, SensitivityClassificationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SensitivityClassificationOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.type, othr.type);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SensitivityClassificationOption FromMutable(ScriptDom.SensitivityClassificationOption fragment) {
            return (SensitivityClassificationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
