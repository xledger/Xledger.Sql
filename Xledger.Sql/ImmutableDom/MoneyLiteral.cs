using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MoneyLiteral : Literal, IEquatable<MoneyLiteral> {
        public MoneyLiteral(string @value = null, Identifier collation = null) {
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.MoneyLiteral ToMutableConcrete() {
            var ret = new ScriptDom.MoneyLiteral();
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
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
            return Equals(obj as MoneyLiteral);
        } 
        
        public bool Equals(MoneyLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MoneyLiteral left, MoneyLiteral right) {
            return EqualityComparer<MoneyLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MoneyLiteral left, MoneyLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MoneyLiteral)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MoneyLiteral left, MoneyLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MoneyLiteral left, MoneyLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MoneyLiteral left, MoneyLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MoneyLiteral left, MoneyLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MoneyLiteral FromMutable(ScriptDom.MoneyLiteral fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MoneyLiteral)) { throw new NotImplementedException("Unexpected subtype of MoneyLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoneyLiteral(
                @value: fragment.Value,
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
