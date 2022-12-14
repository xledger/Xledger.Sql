using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OperatorAuditOption : AuditOption, IEquatable<OperatorAuditOption> {
        protected ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState Value => @value;
    
        public OperatorAuditOption(ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet, ScriptDom.AuditOptionKind optionKind = ScriptDom.AuditOptionKind.QueueDelay) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OperatorAuditOption ToMutableConcrete() {
            var ret = new ScriptDom.OperatorAuditOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OperatorAuditOption);
        } 
        
        public bool Equals(OperatorAuditOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OperatorAuditOption left, OperatorAuditOption right) {
            return EqualityComparer<OperatorAuditOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OperatorAuditOption left, OperatorAuditOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OperatorAuditOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OperatorAuditOption left, OperatorAuditOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OperatorAuditOption left, OperatorAuditOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OperatorAuditOption left, OperatorAuditOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OperatorAuditOption left, OperatorAuditOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OperatorAuditOption FromMutable(ScriptDom.OperatorAuditOption fragment) {
            return (OperatorAuditOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
