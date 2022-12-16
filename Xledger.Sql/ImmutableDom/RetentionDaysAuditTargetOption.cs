using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RetentionDaysAuditTargetOption : AuditTargetOption, IEquatable<RetentionDaysAuditTargetOption> {
        protected Literal days;
    
        public Literal Days => days;
    
        public RetentionDaysAuditTargetOption(Literal days = null, ScriptDom.AuditTargetOptionKind optionKind = ScriptDom.AuditTargetOptionKind.MaxRolloverFiles) {
            this.days = days;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RetentionDaysAuditTargetOption ToMutableConcrete() {
            var ret = new ScriptDom.RetentionDaysAuditTargetOption();
            ret.Days = (ScriptDom.Literal)days?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(days is null)) {
                h = h * 23 + days.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RetentionDaysAuditTargetOption);
        } 
        
        public bool Equals(RetentionDaysAuditTargetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Days, days)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditTargetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) {
            return EqualityComparer<RetentionDaysAuditTargetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RetentionDaysAuditTargetOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.days, othr.days);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RetentionDaysAuditTargetOption left, RetentionDaysAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
