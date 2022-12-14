using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeTrackingDatabaseOption : DatabaseOption, IEquatable<ChangeTrackingDatabaseOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        protected IReadOnlyList<ChangeTrackingOptionDetail> details;
    
        public ScriptDom.OptionState OptionState => optionState;
        public IReadOnlyList<ChangeTrackingOptionDetail> Details => details;
    
        public ChangeTrackingDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, IReadOnlyList<ChangeTrackingOptionDetail> details = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.details = ImmList<ChangeTrackingOptionDetail>.FromList(details);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ChangeTrackingDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.ChangeTrackingDatabaseOption();
            ret.OptionState = optionState;
            ret.Details.AddRange(details.SelectList(c => (ScriptDom.ChangeTrackingOptionDetail)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + details.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ChangeTrackingDatabaseOption);
        } 
        
        public bool Equals(ChangeTrackingDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ChangeTrackingOptionDetail>>.Default.Equals(other.Details, details)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) {
            return EqualityComparer<ChangeTrackingDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ChangeTrackingDatabaseOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.details, othr.details);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ChangeTrackingDatabaseOption FromMutable(ScriptDom.ChangeTrackingDatabaseOption fragment) {
            return (ChangeTrackingDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
