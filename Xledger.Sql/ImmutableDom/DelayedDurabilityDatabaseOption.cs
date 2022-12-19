using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DelayedDurabilityDatabaseOption : DatabaseOption, IEquatable<DelayedDurabilityDatabaseOption> {
        protected ScriptDom.DelayedDurabilityOptionKind @value = ScriptDom.DelayedDurabilityOptionKind.Disabled;
    
        public ScriptDom.DelayedDurabilityOptionKind Value => @value;
    
        public DelayedDurabilityDatabaseOption(ScriptDom.DelayedDurabilityOptionKind @value = ScriptDom.DelayedDurabilityOptionKind.Disabled, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.DelayedDurabilityDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.DelayedDurabilityDatabaseOption();
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
            return Equals(obj as DelayedDurabilityDatabaseOption);
        } 
        
        public bool Equals(DelayedDurabilityDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DelayedDurabilityOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) {
            return EqualityComparer<DelayedDurabilityDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DelayedDurabilityDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DelayedDurabilityDatabaseOption FromMutable(ScriptDom.DelayedDurabilityDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DelayedDurabilityDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of DelayedDurabilityDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DelayedDurabilityDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
