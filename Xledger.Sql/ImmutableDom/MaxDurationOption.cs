using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxDurationOption : IndexOption, IEquatable<MaxDurationOption> {
        protected Literal maxDuration;
        protected ScriptDom.TimeUnit? unit;
    
        public Literal MaxDuration => maxDuration;
        public ScriptDom.TimeUnit? Unit => unit;
    
        public MaxDurationOption(Literal maxDuration = null, ScriptDom.TimeUnit? unit = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.maxDuration = maxDuration;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxDurationOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxDurationOption();
            ret.MaxDuration = (ScriptDom.Literal)maxDuration.ToMutable();
            ret.Unit = unit;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxDuration is null)) {
                h = h * 23 + maxDuration.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxDurationOption);
        } 
        
        public bool Equals(MaxDurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxDuration, maxDuration)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TimeUnit?>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxDurationOption left, MaxDurationOption right) {
            return EqualityComparer<MaxDurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxDurationOption left, MaxDurationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxDurationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.maxDuration, othr.maxDuration);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unit, othr.unit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MaxDurationOption left, MaxDurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxDurationOption left, MaxDurationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxDurationOption left, MaxDurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxDurationOption left, MaxDurationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MaxDurationOption FromMutable(ScriptDom.MaxDurationOption fragment) {
            return (MaxDurationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
