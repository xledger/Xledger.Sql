using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxDispatchLatencySessionOption : SessionOption, IEquatable<MaxDispatchLatencySessionOption> {
        protected bool isInfinite = false;
        protected Literal @value;
    
        public bool IsInfinite => isInfinite;
        public Literal Value => @value;
    
        public MaxDispatchLatencySessionOption(bool isInfinite = false, Literal @value = null, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.isInfinite = isInfinite;
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxDispatchLatencySessionOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxDispatchLatencySessionOption();
            ret.IsInfinite = isInfinite;
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isInfinite.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxDispatchLatencySessionOption);
        } 
        
        public bool Equals(MaxDispatchLatencySessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsInfinite, isInfinite)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) {
            return EqualityComparer<MaxDispatchLatencySessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxDispatchLatencySessionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isInfinite, othr.isInfinite);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MaxDispatchLatencySessionOption FromMutable(ScriptDom.MaxDispatchLatencySessionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MaxDispatchLatencySessionOption)) { throw new NotImplementedException("Unexpected subtype of MaxDispatchLatencySessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxDispatchLatencySessionOption(
                isInfinite: fragment.IsInfinite,
                @value: ImmutableDom.Literal.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
