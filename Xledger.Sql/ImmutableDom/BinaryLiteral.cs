using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BinaryLiteral : Literal, IEquatable<BinaryLiteral> {
        protected bool isLargeObject = false;
    
        public bool IsLargeObject => isLargeObject;
    
        public BinaryLiteral(bool isLargeObject = false, string @value = null, Identifier collation = null) {
            this.isLargeObject = isLargeObject;
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.BinaryLiteral ToMutableConcrete() {
            var ret = new ScriptDom.BinaryLiteral();
            ret.IsLargeObject = isLargeObject;
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
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
            return Equals(obj as BinaryLiteral);
        } 
        
        public bool Equals(BinaryLiteral other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(BinaryLiteral left, BinaryLiteral right) {
            return EqualityComparer<BinaryLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BinaryLiteral left, BinaryLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BinaryLiteral)that;
            compare = Comparer.DefaultInvariant.Compare(this.isLargeObject, othr.isLargeObject);
            if (compare != 0) { return compare; }
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (BinaryLiteral left, BinaryLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BinaryLiteral left, BinaryLiteral right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BinaryLiteral left, BinaryLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BinaryLiteral left, BinaryLiteral right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BinaryLiteral FromMutable(ScriptDom.BinaryLiteral fragment) {
            return (BinaryLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
