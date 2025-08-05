using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class Identifier : TSqlFragment, IEquatable<Identifier> {
        protected string @value;
        protected ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted;
    
        public string Value => @value;
        public ScriptDom.QuoteType QuoteType => quoteType;
    
        public Identifier(string @value = null, ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted) {
            this.@value = @value;
            this.quoteType = quoteType;
        }
    
        public ScriptDom.Identifier ToMutableConcrete() {
            var ret = new ScriptDom.Identifier();
            ret.Value = @value;
            ret.QuoteType = quoteType;
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
            h = h * 23 + quoteType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as Identifier);
        } 
        
        public bool Equals(Identifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QuoteType>.Default.Equals(other.QuoteType, quoteType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(Identifier left, Identifier right) {
            return EqualityComparer<Identifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Identifier left, Identifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (Identifier)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.quoteType, othr.quoteType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (Identifier left, Identifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(Identifier left, Identifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (Identifier left, Identifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(Identifier left, Identifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static Identifier FromMutable(ScriptDom.Identifier fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.Identifier)) { return TSqlFragment.FromMutable(fragment) as Identifier; }
            return new Identifier(
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
    
    }

}
