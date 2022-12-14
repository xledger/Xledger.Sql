using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralOptionValue : OptionValue, IEquatable<LiteralOptionValue> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralOptionValue(Literal @value = null) {
            this.@value = @value;
        }
    
        public ScriptDom.LiteralOptionValue ToMutableConcrete() {
            var ret = new ScriptDom.LiteralOptionValue();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralOptionValue);
        } 
        
        public bool Equals(LiteralOptionValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralOptionValue left, LiteralOptionValue right) {
            return EqualityComparer<LiteralOptionValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralOptionValue left, LiteralOptionValue right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralOptionValue)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static LiteralOptionValue FromMutable(ScriptDom.LiteralOptionValue fragment) {
            return (LiteralOptionValue)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
