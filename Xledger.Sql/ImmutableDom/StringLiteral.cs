using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StringLiteral : Literal, IEquatable<StringLiteral> {
        protected bool isNational = false;
        protected bool isLargeObject = false;
    
        public bool IsNational => isNational;
        public bool IsLargeObject => isLargeObject;
    
        public StringLiteral(bool isNational = false, bool isLargeObject = false, string @value = null, Identifier collation = null) {
            this.isNational = isNational;
            this.isLargeObject = isLargeObject;
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.StringLiteral ToMutableConcrete() {
            var ret = new ScriptDom.StringLiteral();
            ret.IsNational = isNational;
            ret.IsLargeObject = isLargeObject;
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isNational.GetHashCode();
            h = h * 23 + isLargeObject.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StringLiteral);
        } 
        
        public bool Equals(StringLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNational, isNational)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsLargeObject, isLargeObject)) {
                return false;
            }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StringLiteral left, StringLiteral right) {
            return EqualityComparer<StringLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StringLiteral left, StringLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (StringLiteral)that;
            compare = Comparer.DefaultInvariant.Compare(this.isNational, othr.isNational);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isLargeObject, othr.isLargeObject);
            if (compare != 0) { return compare; }
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (StringLiteral left, StringLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(StringLiteral left, StringLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (StringLiteral left, StringLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(StringLiteral left, StringLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static StringLiteral FromMutable(ScriptDom.StringLiteral fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.StringLiteral)) { throw new NotImplementedException("Unexpected subtype of StringLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StringLiteral(
                isNational: fragment.IsNational,
                isLargeObject: fragment.IsLargeObject,
                @value: fragment.Value,
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
