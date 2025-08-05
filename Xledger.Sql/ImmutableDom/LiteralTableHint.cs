using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralTableHint : TableHint, IEquatable<LiteralTableHint> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralTableHint(Literal @value = null, ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.@value = @value;
            this.hintKind = hintKind;
        }
    
        public new ScriptDom.LiteralTableHint ToMutableConcrete() {
            var ret = new ScriptDom.LiteralTableHint();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
            ret.HintKind = hintKind;
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
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralTableHint);
        } 
        
        public bool Equals(LiteralTableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralTableHint left, LiteralTableHint right) {
            return EqualityComparer<LiteralTableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralTableHint left, LiteralTableHint right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralTableHint)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.hintKind, othr.hintKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (LiteralTableHint left, LiteralTableHint right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LiteralTableHint left, LiteralTableHint right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LiteralTableHint left, LiteralTableHint right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LiteralTableHint left, LiteralTableHint right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static LiteralTableHint FromMutable(ScriptDom.LiteralTableHint fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.LiteralTableHint)) { throw new NotImplementedException("Unexpected subtype of LiteralTableHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralTableHint(
                @value: ImmutableDom.Literal.FromMutable(fragment.Value),
                hintKind: fragment.HintKind
            );
        }
    
    }

}
