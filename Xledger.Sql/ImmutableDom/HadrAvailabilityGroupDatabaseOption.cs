using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class HadrAvailabilityGroupDatabaseOption : HadrDatabaseOption, IEquatable<HadrAvailabilityGroupDatabaseOption> {
        protected Identifier groupName;
    
        public Identifier GroupName => groupName;
    
        public HadrAvailabilityGroupDatabaseOption(Identifier groupName = null, ScriptDom.HadrDatabaseOptionKind hadrOption = ScriptDom.HadrDatabaseOptionKind.Suspend, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.groupName = groupName;
            this.hadrOption = hadrOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.HadrAvailabilityGroupDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.HadrAvailabilityGroupDatabaseOption();
            ret.GroupName = (ScriptDom.Identifier)groupName.ToMutable();
            ret.HadrOption = hadrOption;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(groupName is null)) {
                h = h * 23 + groupName.GetHashCode();
            }
            h = h * 23 + hadrOption.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as HadrAvailabilityGroupDatabaseOption);
        } 
        
        public bool Equals(HadrAvailabilityGroupDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GroupName, groupName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.HadrDatabaseOptionKind>.Default.Equals(other.HadrOption, hadrOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(HadrAvailabilityGroupDatabaseOption left, HadrAvailabilityGroupDatabaseOption right) {
            return EqualityComparer<HadrAvailabilityGroupDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(HadrAvailabilityGroupDatabaseOption left, HadrAvailabilityGroupDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (HadrAvailabilityGroupDatabaseOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.groupName, othr.groupName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.hadrOption, othr.hadrOption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static HadrAvailabilityGroupDatabaseOption FromMutable(ScriptDom.HadrAvailabilityGroupDatabaseOption fragment) {
            return (HadrAvailabilityGroupDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
