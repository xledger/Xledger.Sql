using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralAuditTargetOption : AuditTargetOption, IEquatable<LiteralAuditTargetOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralAuditTargetOption(Literal @value = null, ScriptDom.AuditTargetOptionKind optionKind = ScriptDom.AuditTargetOptionKind.MaxRolloverFiles) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralAuditTargetOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralAuditTargetOption();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
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
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralAuditTargetOption);
        } 
        
        public bool Equals(LiteralAuditTargetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditTargetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralAuditTargetOption left, LiteralAuditTargetOption right) {
            return EqualityComparer<LiteralAuditTargetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralAuditTargetOption left, LiteralAuditTargetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralAuditTargetOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LiteralAuditTargetOption left, LiteralAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LiteralAuditTargetOption left, LiteralAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LiteralAuditTargetOption left, LiteralAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LiteralAuditTargetOption left, LiteralAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
