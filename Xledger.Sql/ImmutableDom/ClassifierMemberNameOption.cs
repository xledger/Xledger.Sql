using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierMemberNameOption : WorkloadClassifierOption, IEquatable<ClassifierMemberNameOption> {
        protected StringLiteral memberName;
    
        public StringLiteral MemberName => memberName;
    
        public ClassifierMemberNameOption(StringLiteral memberName = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.memberName = memberName;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierMemberNameOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierMemberNameOption();
            ret.MemberName = (ScriptDom.StringLiteral)memberName?.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(memberName is null)) {
                h = h * 23 + memberName.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierMemberNameOption);
        } 
        
        public bool Equals(ClassifierMemberNameOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.MemberName, memberName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierMemberNameOption left, ClassifierMemberNameOption right) {
            return EqualityComparer<ClassifierMemberNameOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierMemberNameOption left, ClassifierMemberNameOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClassifierMemberNameOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.memberName, othr.memberName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionType, othr.optionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ClassifierMemberNameOption left, ClassifierMemberNameOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ClassifierMemberNameOption left, ClassifierMemberNameOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ClassifierMemberNameOption left, ClassifierMemberNameOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ClassifierMemberNameOption left, ClassifierMemberNameOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
