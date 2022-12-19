using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierSnippet : Identifier, IEquatable<IdentifierSnippet> {
        protected string script;
    
        public string Script => script;
    
        public IdentifierSnippet(string script = null, string @value = null, ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted) {
            this.script = script;
            this.@value = @value;
            this.quoteType = quoteType;
        }
    
        public new ScriptDom.IdentifierSnippet ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierSnippet();
            ret.Script = script;
            ret.Value = @value;
            ret.QuoteType = quoteType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(script is null)) {
                h = h * 23 + script.GetHashCode();
            }
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + quoteType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentifierSnippet);
        } 
        
        public bool Equals(IdentifierSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QuoteType>.Default.Equals(other.QuoteType, quoteType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierSnippet left, IdentifierSnippet right) {
            return EqualityComparer<IdentifierSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierSnippet left, IdentifierSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentifierSnippet)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.quoteType, othr.quoteType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (IdentifierSnippet left, IdentifierSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IdentifierSnippet left, IdentifierSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IdentifierSnippet left, IdentifierSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IdentifierSnippet left, IdentifierSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static IdentifierSnippet FromMutable(ScriptDom.IdentifierSnippet fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.IdentifierSnippet)) { throw new NotImplementedException("Unexpected subtype of IdentifierSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierSnippet(
                script: fragment.Script,
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
    
    }

}
