using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditGuidAuditOption : AuditOption, IEquatable<AuditGuidAuditOption> {
        protected Literal guid;
    
        public Literal Guid => guid;
    
        public AuditGuidAuditOption(Literal guid = null, ScriptDom.AuditOptionKind optionKind = ScriptDom.AuditOptionKind.QueueDelay) {
            this.guid = guid;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AuditGuidAuditOption ToMutableConcrete() {
            var ret = new ScriptDom.AuditGuidAuditOption();
            ret.Guid = (ScriptDom.Literal)guid.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(guid is null)) {
                h = h * 23 + guid.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuditGuidAuditOption);
        } 
        
        public bool Equals(AuditGuidAuditOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Guid, guid)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuditGuidAuditOption left, AuditGuidAuditOption right) {
            return EqualityComparer<AuditGuidAuditOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuditGuidAuditOption left, AuditGuidAuditOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AuditGuidAuditOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.guid, othr.guid);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AuditGuidAuditOption FromMutable(ScriptDom.AuditGuidAuditOption fragment) {
            return (AuditGuidAuditOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
