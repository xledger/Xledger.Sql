using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralSessionOption : SessionOption, IEquatable<LiteralSessionOption> {
        protected Literal @value;
        protected ScriptDom.MemoryUnit unit = ScriptDom.MemoryUnit.Unspecified;
    
        public Literal Value => @value;
        public ScriptDom.MemoryUnit Unit => unit;
    
        public LiteralSessionOption(Literal @value = null, ScriptDom.MemoryUnit unit = ScriptDom.MemoryUnit.Unspecified, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.@value = @value;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralSessionOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralSessionOption();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
            ret.Unit = unit;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralSessionOption);
        } 
        
        public bool Equals(LiteralSessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralSessionOption left, LiteralSessionOption right) {
            return EqualityComparer<LiteralSessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralSessionOption left, LiteralSessionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralSessionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unit, othr.unit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (LiteralSessionOption left, LiteralSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LiteralSessionOption left, LiteralSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LiteralSessionOption left, LiteralSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LiteralSessionOption left, LiteralSessionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static LiteralSessionOption FromMutable(ScriptDom.LiteralSessionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.LiteralSessionOption)) { throw new NotImplementedException("Unexpected subtype of LiteralSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralSessionOption(
                @value: ImmutableDom.Literal.FromMutable(fragment.Value),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
