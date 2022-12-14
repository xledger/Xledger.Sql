using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetFipsFlaggerCommand : SetCommand, IEquatable<SetFipsFlaggerCommand> {
        protected ScriptDom.FipsComplianceLevel complianceLevel = ScriptDom.FipsComplianceLevel.Off;
    
        public ScriptDom.FipsComplianceLevel ComplianceLevel => complianceLevel;
    
        public SetFipsFlaggerCommand(ScriptDom.FipsComplianceLevel complianceLevel = ScriptDom.FipsComplianceLevel.Off) {
            this.complianceLevel = complianceLevel;
        }
    
        public ScriptDom.SetFipsFlaggerCommand ToMutableConcrete() {
            var ret = new ScriptDom.SetFipsFlaggerCommand();
            ret.ComplianceLevel = complianceLevel;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + complianceLevel.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetFipsFlaggerCommand);
        } 
        
        public bool Equals(SetFipsFlaggerCommand other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FipsComplianceLevel>.Default.Equals(other.ComplianceLevel, complianceLevel)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetFipsFlaggerCommand left, SetFipsFlaggerCommand right) {
            return EqualityComparer<SetFipsFlaggerCommand>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetFipsFlaggerCommand left, SetFipsFlaggerCommand right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetFipsFlaggerCommand)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.complianceLevel, othr.complianceLevel);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SetFipsFlaggerCommand FromMutable(ScriptDom.SetFipsFlaggerCommand fragment) {
            return (SetFipsFlaggerCommand)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
