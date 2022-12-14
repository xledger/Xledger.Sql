using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierWlmLabelOption : WorkloadClassifierOption, IEquatable<ClassifierWlmLabelOption> {
        protected StringLiteral wlmLabel;
    
        public StringLiteral WlmLabel => wlmLabel;
    
        public ClassifierWlmLabelOption(StringLiteral wlmLabel = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.wlmLabel = wlmLabel;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierWlmLabelOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierWlmLabelOption();
            ret.WlmLabel = (ScriptDom.StringLiteral)wlmLabel.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(wlmLabel is null)) {
                h = h * 23 + wlmLabel.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierWlmLabelOption);
        } 
        
        public bool Equals(ClassifierWlmLabelOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.WlmLabel, wlmLabel)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierWlmLabelOption left, ClassifierWlmLabelOption right) {
            return EqualityComparer<ClassifierWlmLabelOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierWlmLabelOption left, ClassifierWlmLabelOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClassifierWlmLabelOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.wlmLabel, othr.wlmLabel);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionType, othr.optionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ClassifierWlmLabelOption FromMutable(ScriptDom.ClassifierWlmLabelOption fragment) {
            return (ClassifierWlmLabelOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
