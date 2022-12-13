using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralEndpointProtocolOption : EndpointProtocolOption, IEquatable<LiteralEndpointProtocolOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralEndpointProtocolOption(Literal @value = null, ScriptDom.EndpointProtocolOptions kind = ScriptDom.EndpointProtocolOptions.None) {
            this.@value = @value;
            this.kind = kind;
        }
    
        public ScriptDom.LiteralEndpointProtocolOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralEndpointProtocolOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.Kind = kind;
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
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralEndpointProtocolOption);
        } 
        
        public bool Equals(LiteralEndpointProtocolOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocolOptions>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralEndpointProtocolOption left, LiteralEndpointProtocolOption right) {
            return EqualityComparer<LiteralEndpointProtocolOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralEndpointProtocolOption left, LiteralEndpointProtocolOption right) {
            return !(left == right);
        }
    
        public static LiteralEndpointProtocolOption FromMutable(ScriptDom.LiteralEndpointProtocolOption fragment) {
            return (LiteralEndpointProtocolOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
