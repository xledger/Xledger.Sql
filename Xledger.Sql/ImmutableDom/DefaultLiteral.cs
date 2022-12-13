using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DefaultLiteral : Literal, IEquatable<DefaultLiteral> {
        public DefaultLiteral(string @value = null, Identifier collation = null) {
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.DefaultLiteral ToMutableConcrete() {
            var ret = new ScriptDom.DefaultLiteral();
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
            return Equals(obj as DefaultLiteral);
        } 
        
        public bool Equals(DefaultLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DefaultLiteral left, DefaultLiteral right) {
            return EqualityComparer<DefaultLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DefaultLiteral left, DefaultLiteral right) {
            return !(left == right);
        }
    
        public static DefaultLiteral FromMutable(ScriptDom.DefaultLiteral fragment) {
            return (DefaultLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
