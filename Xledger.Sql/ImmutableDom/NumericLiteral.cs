using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NumericLiteral : Literal, IEquatable<NumericLiteral> {
        public NumericLiteral(string @value = null, Identifier collation = null) {
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.NumericLiteral ToMutableConcrete() {
            var ret = new ScriptDom.NumericLiteral();
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
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
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NumericLiteral);
        } 
        
        public bool Equals(NumericLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NumericLiteral left, NumericLiteral right) {
            return EqualityComparer<NumericLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NumericLiteral left, NumericLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (NumericLiteral)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (NumericLiteral left, NumericLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(NumericLiteral left, NumericLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (NumericLiteral left, NumericLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(NumericLiteral left, NumericLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static NumericLiteral FromMutable(ScriptDom.NumericLiteral fragment) {
            return (NumericLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
