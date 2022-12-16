using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierWlmContextOption : WorkloadClassifierOption, IEquatable<ClassifierWlmContextOption> {
        protected StringLiteral wlmContext;
    
        public StringLiteral WlmContext => wlmContext;
    
        public ClassifierWlmContextOption(StringLiteral wlmContext = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.wlmContext = wlmContext;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierWlmContextOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierWlmContextOption();
            ret.WlmContext = (ScriptDom.StringLiteral)wlmContext?.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(wlmContext is null)) {
                h = h * 23 + wlmContext.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierWlmContextOption);
        } 
        
        public bool Equals(ClassifierWlmContextOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.WlmContext, wlmContext)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierWlmContextOption left, ClassifierWlmContextOption right) {
            return EqualityComparer<ClassifierWlmContextOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierWlmContextOption left, ClassifierWlmContextOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClassifierWlmContextOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.wlmContext, othr.wlmContext);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionType, othr.optionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ClassifierWlmContextOption left, ClassifierWlmContextOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ClassifierWlmContextOption left, ClassifierWlmContextOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ClassifierWlmContextOption left, ClassifierWlmContextOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ClassifierWlmContextOption left, ClassifierWlmContextOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
