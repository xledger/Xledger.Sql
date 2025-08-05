using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FailoverModeReplicaOption : AvailabilityReplicaOption, IEquatable<FailoverModeReplicaOption> {
        protected ScriptDom.FailoverModeOptionKind @value = ScriptDom.FailoverModeOptionKind.Automatic;
    
        public ScriptDom.FailoverModeOptionKind Value => @value;
    
        public FailoverModeReplicaOption(ScriptDom.FailoverModeOptionKind @value = ScriptDom.FailoverModeOptionKind.Automatic, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FailoverModeReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.FailoverModeReplicaOption();
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
            return Equals(obj as FailoverModeReplicaOption);
        } 
        
        public bool Equals(FailoverModeReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FailoverModeOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FailoverModeReplicaOption left, FailoverModeReplicaOption right) {
            return EqualityComparer<FailoverModeReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FailoverModeReplicaOption left, FailoverModeReplicaOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FailoverModeReplicaOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FailoverModeReplicaOption left, FailoverModeReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FailoverModeReplicaOption left, FailoverModeReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FailoverModeReplicaOption left, FailoverModeReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FailoverModeReplicaOption left, FailoverModeReplicaOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FailoverModeReplicaOption FromMutable(ScriptDom.FailoverModeReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FailoverModeReplicaOption)) { throw new NotImplementedException("Unexpected subtype of FailoverModeReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FailoverModeReplicaOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
