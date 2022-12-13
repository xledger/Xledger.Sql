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
    
        public ScriptDom.IdentifierSnippet ToMutableConcrete() {
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
    
        public static IdentifierSnippet FromMutable(ScriptDom.IdentifierSnippet fragment) {
            return (IdentifierSnippet)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
