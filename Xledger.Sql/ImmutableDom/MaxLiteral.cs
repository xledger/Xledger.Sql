using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxLiteral : Literal, IEquatable<MaxLiteral> {
        public MaxLiteral(string @value = null, Identifier collation = null) {
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.MaxLiteral ToMutableConcrete() {
            var ret = new ScriptDom.MaxLiteral();
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
            return Equals(obj as MaxLiteral);
        } 
        
        public bool Equals(MaxLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxLiteral left, MaxLiteral right) {
            return EqualityComparer<MaxLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxLiteral left, MaxLiteral right) {
            return !(left == right);
        }
    
        public static MaxLiteral FromMutable(ScriptDom.MaxLiteral fragment) {
            return (MaxLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
