using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierLiteral : Literal, IEquatable<IdentifierLiteral> {
        protected ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted;
    
        public ScriptDom.QuoteType QuoteType => quoteType;
    
        public IdentifierLiteral(ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted, string @value = null, Identifier collation = null) {
            this.quoteType = quoteType;
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.IdentifierLiteral ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierLiteral();
            ret.QuoteType = quoteType;
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + quoteType.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentifierLiteral);
        } 
        
        public bool Equals(IdentifierLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QuoteType>.Default.Equals(other.QuoteType, quoteType)) {
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
        
        public static bool operator ==(IdentifierLiteral left, IdentifierLiteral right) {
            return EqualityComparer<IdentifierLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierLiteral left, IdentifierLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentifierLiteral)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.quoteType, othr.quoteType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static IdentifierLiteral FromMutable(ScriptDom.IdentifierLiteral fragment) {
            return (IdentifierLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
