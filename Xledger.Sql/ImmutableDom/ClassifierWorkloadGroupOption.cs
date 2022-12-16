using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierWorkloadGroupOption : WorkloadClassifierOption, IEquatable<ClassifierWorkloadGroupOption> {
        protected StringLiteral workloadGroupName;
    
        public StringLiteral WorkloadGroupName => workloadGroupName;
    
        public ClassifierWorkloadGroupOption(StringLiteral workloadGroupName = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.workloadGroupName = workloadGroupName;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierWorkloadGroupOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierWorkloadGroupOption();
            ret.WorkloadGroupName = (ScriptDom.StringLiteral)workloadGroupName?.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(workloadGroupName is null)) {
                h = h * 23 + workloadGroupName.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierWorkloadGroupOption);
        } 
        
        public bool Equals(ClassifierWorkloadGroupOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.WorkloadGroupName, workloadGroupName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) {
            return EqualityComparer<ClassifierWorkloadGroupOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClassifierWorkloadGroupOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.workloadGroupName, othr.workloadGroupName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionType, othr.optionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ClassifierWorkloadGroupOption left, ClassifierWorkloadGroupOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
