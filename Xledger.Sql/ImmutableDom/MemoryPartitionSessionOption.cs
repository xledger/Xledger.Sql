using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MemoryPartitionSessionOption : SessionOption, IEquatable<MemoryPartitionSessionOption> {
        protected ScriptDom.EventSessionMemoryPartitionModeType @value = ScriptDom.EventSessionMemoryPartitionModeType.Unknown;
    
        public ScriptDom.EventSessionMemoryPartitionModeType Value => @value;
    
        public MemoryPartitionSessionOption(ScriptDom.EventSessionMemoryPartitionModeType @value = ScriptDom.EventSessionMemoryPartitionModeType.Unknown, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MemoryPartitionSessionOption ToMutableConcrete() {
            var ret = new ScriptDom.MemoryPartitionSessionOption();
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
            return Equals(obj as MemoryPartitionSessionOption);
        } 
        
        public bool Equals(MemoryPartitionSessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventSessionMemoryPartitionModeType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) {
            return EqualityComparer<MemoryPartitionSessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MemoryPartitionSessionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MemoryPartitionSessionOption FromMutable(ScriptDom.MemoryPartitionSessionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MemoryPartitionSessionOption)) { throw new NotImplementedException("Unexpected subtype of MemoryPartitionSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MemoryPartitionSessionOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
