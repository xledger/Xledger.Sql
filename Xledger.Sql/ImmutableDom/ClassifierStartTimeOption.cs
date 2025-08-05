using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierStartTimeOption : WorkloadClassifierOption, IEquatable<ClassifierStartTimeOption> {
        protected WlmTimeLiteral time;
    
        public WlmTimeLiteral Time => time;
    
        public ClassifierStartTimeOption(WlmTimeLiteral time = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.time = time;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierStartTimeOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierStartTimeOption();
            ret.Time = (ScriptDom.WlmTimeLiteral)time?.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(time is null)) {
                h = h * 23 + time.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierStartTimeOption);
        } 
        
        public bool Equals(ClassifierStartTimeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<WlmTimeLiteral>.Default.Equals(other.Time, time)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierStartTimeOption left, ClassifierStartTimeOption right) {
            return EqualityComparer<ClassifierStartTimeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierStartTimeOption left, ClassifierStartTimeOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClassifierStartTimeOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.time, othr.time);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionType, othr.optionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ClassifierStartTimeOption left, ClassifierStartTimeOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ClassifierStartTimeOption left, ClassifierStartTimeOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ClassifierStartTimeOption left, ClassifierStartTimeOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ClassifierStartTimeOption left, ClassifierStartTimeOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ClassifierStartTimeOption FromMutable(ScriptDom.ClassifierStartTimeOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ClassifierStartTimeOption)) { throw new NotImplementedException("Unexpected subtype of ClassifierStartTimeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierStartTimeOption(
                time: ImmutableDom.WlmTimeLiteral.FromMutable(fragment.Time),
                optionType: fragment.OptionType
            );
        }
    
    }

}
