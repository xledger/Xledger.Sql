using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeTrackingDatabaseOption : DatabaseOption, IEquatable<ChangeTrackingDatabaseOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        protected IReadOnlyList<ChangeTrackingOptionDetail> details;
    
        public ScriptDom.OptionState OptionState => optionState;
        public IReadOnlyList<ChangeTrackingOptionDetail> Details => details;
    
        public ChangeTrackingDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, IReadOnlyList<ChangeTrackingOptionDetail> details = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.details = details.ToImmArray<ChangeTrackingOptionDetail>();
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ChangeTrackingDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.ChangeTrackingDatabaseOption();
            ret.OptionState = optionState;
            ret.Details.AddRange(details.Select(c => (ScriptDom.ChangeTrackingOptionDetail)c?.ToMutable()));
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
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.details, othr.details);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ChangeTrackingDatabaseOption left, ChangeTrackingDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ChangeTrackingDatabaseOption FromMutable(ScriptDom.ChangeTrackingDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ChangeTrackingDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of ChangeTrackingDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTrackingDatabaseOption(
                optionState: fragment.OptionState,
                details: fragment.Details.ToImmArray(ImmutableDom.ChangeTrackingOptionDetail.FromMutable),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
