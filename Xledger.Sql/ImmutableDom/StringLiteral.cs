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
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
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
    
        public static StringLiteral FromMutable(ScriptDom.StringLiteral fragment) {
            return (StringLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
