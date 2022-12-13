using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlNamespacesDefaultElement : XmlNamespacesElement, IEquatable<XmlNamespacesDefaultElement> {
        public XmlNamespacesDefaultElement(StringLiteral @string = null) {
            this.@string = @string;
        }
    
        public ScriptDom.XmlNamespacesDefaultElement ToMutableConcrete() {
            var ret = new ScriptDom.XmlNamespacesDefaultElement();
            ret.String = (ScriptDom.StringLiteral)@string.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@string is null)) {
                h = h * 23 + @string.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlNamespacesDefaultElement);
        } 
        
        public bool Equals(XmlNamespacesDefaultElement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.String, @string)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlNamespacesDefaultElement left, XmlNamespacesDefaultElement right) {
            return EqualityComparer<XmlNamespacesDefaultElement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlNamespacesDefaultElement left, XmlNamespacesDefaultElement right) {
            return !(left == right);
        }
    
        public static XmlNamespacesDefaultElement FromMutable(ScriptDom.XmlNamespacesDefaultElement fragment) {
            return (XmlNamespacesDefaultElement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
