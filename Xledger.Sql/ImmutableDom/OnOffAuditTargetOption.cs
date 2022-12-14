using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffAuditTargetOption : AuditTargetOption, IEquatable<OnOffAuditTargetOption> {
        protected ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState Value => @value;
    
        public OnOffAuditTargetOption(ScriptDom.OptionState @value = ScriptDom.OptionState.NotSet, ScriptDom.AuditTargetOptionKind optionKind = ScriptDom.AuditTargetOptionKind.MaxRolloverFiles) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffAuditTargetOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffAuditTargetOption();
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
            return Equals(obj as OnOffAuditTargetOption);
        } 
        
        public bool Equals(OnOffAuditTargetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditTargetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffAuditTargetOption left, OnOffAuditTargetOption right) {
            return EqualityComparer<OnOffAuditTargetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffAuditTargetOption left, OnOffAuditTargetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OnOffAuditTargetOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OnOffAuditTargetOption FromMutable(ScriptDom.OnOffAuditTargetOption fragment) {
            return (OnOffAuditTargetOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
