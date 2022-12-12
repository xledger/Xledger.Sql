using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlNamespaces : TSqlFragment, IEquatable<XmlNamespaces> {
        protected IReadOnlyList<XmlNamespacesElement> xmlNamespacesElements;
    
        public IReadOnlyList<XmlNamespacesElement> XmlNamespacesElements => xmlNamespacesElements;
    
        public XmlNamespaces(IReadOnlyList<XmlNamespacesElement> xmlNamespacesElements = null) {
            this.xmlNamespacesElements = xmlNamespacesElements is null ? ImmList<XmlNamespacesElement>.Empty : ImmList<XmlNamespacesElement>.FromList(xmlNamespacesElements);
        }
    
        public ScriptDom.XmlNamespaces ToMutableConcrete() {
            var ret = new ScriptDom.XmlNamespaces();
            ret.XmlNamespacesElements.AddRange(xmlNamespacesElements.SelectList(c => (ScriptDom.XmlNamespacesElement)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + xmlNamespacesElements.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlNamespaces);
        } 
        
        public bool Equals(XmlNamespaces other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<XmlNamespacesElement>>.Default.Equals(other.XmlNamespacesElements, xmlNamespacesElements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlNamespaces left, XmlNamespaces right) {
            return EqualityComparer<XmlNamespaces>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlNamespaces left, XmlNamespaces right) {
            return !(left == right);
        }
    
    }

}
