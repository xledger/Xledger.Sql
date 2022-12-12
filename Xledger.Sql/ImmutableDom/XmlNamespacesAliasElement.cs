using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlNamespacesAliasElement : XmlNamespacesElement, IEquatable<XmlNamespacesAliasElement> {
        Identifier identifier;
    
        public Identifier Identifier => identifier;
    
        public XmlNamespacesAliasElement(Identifier identifier = null, StringLiteral @string = null) {
            this.identifier = identifier;
            this.@string = @string;
        }
    
        public ScriptDom.XmlNamespacesAliasElement ToMutableConcrete() {
            var ret = new ScriptDom.XmlNamespacesAliasElement();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.String = (ScriptDom.StringLiteral)@string.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            if (!(@string is null)) {
                h = h * 23 + @string.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlNamespacesAliasElement);
        } 
        
        public bool Equals(XmlNamespacesAliasElement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.String, @string)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) {
            return EqualityComparer<XmlNamespacesAliasElement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) {
            return !(left == right);
        }
    
    }

}