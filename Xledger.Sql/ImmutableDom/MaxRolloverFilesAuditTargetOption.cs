using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxRolloverFilesAuditTargetOption : AuditTargetOption, IEquatable<MaxRolloverFilesAuditTargetOption> {
        protected Literal @value;
        protected bool isUnlimited = false;
    
        public Literal Value => @value;
        public bool IsUnlimited => isUnlimited;
    
        public MaxRolloverFilesAuditTargetOption(Literal @value = null, bool isUnlimited = false, ScriptDom.AuditTargetOptionKind optionKind = ScriptDom.AuditTargetOptionKind.MaxRolloverFiles) {
            this.@value = @value;
            this.isUnlimited = isUnlimited;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxRolloverFilesAuditTargetOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxRolloverFilesAuditTargetOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.IsUnlimited = isUnlimited;
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
            h = h * 23 + isUnlimited.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxRolloverFilesAuditTargetOption);
        } 
        
        public bool Equals(MaxRolloverFilesAuditTargetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsUnlimited, isUnlimited)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditTargetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) {
            return EqualityComparer<MaxRolloverFilesAuditTargetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxRolloverFilesAuditTargetOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isUnlimited, othr.isUnlimited);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxRolloverFilesAuditTargetOption left, MaxRolloverFilesAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
