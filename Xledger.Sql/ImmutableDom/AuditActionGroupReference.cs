using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditActionGroupReference : AuditSpecificationDetail, IEquatable<AuditActionGroupReference> {
        protected ScriptDom.AuditActionGroup group = ScriptDom.AuditActionGroup.None;
    
        public ScriptDom.AuditActionGroup Group => group;
    
        public AuditActionGroupReference(ScriptDom.AuditActionGroup group = ScriptDom.AuditActionGroup.None) {
            this.group = group;
        }
    
        public ScriptDom.AuditActionGroupReference ToMutableConcrete() {
            var ret = new ScriptDom.AuditActionGroupReference();
            ret.Group = group;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + group.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuditActionGroupReference);
        } 
        
        public bool Equals(AuditActionGroupReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AuditActionGroup>.Default.Equals(other.Group, group)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuditActionGroupReference left, AuditActionGroupReference right) {
            return EqualityComparer<AuditActionGroupReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuditActionGroupReference left, AuditActionGroupReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AuditActionGroupReference)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.group, othr.group);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AuditActionGroupReference FromMutable(ScriptDom.AuditActionGroupReference fragment) {
            return (AuditActionGroupReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
