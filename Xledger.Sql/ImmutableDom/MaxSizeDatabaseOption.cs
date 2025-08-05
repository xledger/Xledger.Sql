using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxSizeDatabaseOption : DatabaseOption, IEquatable<MaxSizeDatabaseOption> {
        protected Literal maxSize;
        protected ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified;
    
        public Literal MaxSize => maxSize;
        public ScriptDom.MemoryUnit Units => units;
    
        public MaxSizeDatabaseOption(Literal maxSize = null, ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.maxSize = maxSize;
            this.units = units;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.MaxSizeDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxSizeDatabaseOption();
            ret.MaxSize = (ScriptDom.Literal)maxSize?.ToMutable();
            ret.Units = units;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxSize is null)) {
                h = h * 23 + maxSize.GetHashCode();
            }
            h = h * 23 + units.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxSizeDatabaseOption);
        } 
        
        public bool Equals(MaxSizeDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxSize, maxSize)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.Units, units)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) {
            return EqualityComparer<MaxSizeDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxSizeDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.maxSize, othr.maxSize);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.units, othr.units);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxSizeDatabaseOption left, MaxSizeDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MaxSizeDatabaseOption FromMutable(ScriptDom.MaxSizeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MaxSizeDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of MaxSizeDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxSizeDatabaseOption(
                maxSize: ImmutableDom.Literal.FromMutable(fragment.MaxSize),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
