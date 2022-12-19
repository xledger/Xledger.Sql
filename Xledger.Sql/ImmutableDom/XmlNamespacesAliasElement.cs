using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlNamespacesAliasElement : XmlNamespacesElement, IEquatable<XmlNamespacesAliasElement> {
        protected Identifier identifier;
    
        public Identifier Identifier => identifier;
    
        public XmlNamespacesAliasElement(Identifier identifier = null, StringLiteral @string = null) {
            this.identifier = identifier;
            this.@string = @string;
        }
    
        public ScriptDom.XmlNamespacesAliasElement ToMutableConcrete() {
            var ret = new ScriptDom.XmlNamespacesAliasElement();
            ret.Identifier = (ScriptDom.Identifier)identifier?.ToMutable();
            ret.String = (ScriptDom.StringLiteral)@string?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (XmlNamespacesAliasElement)that;
            compare = Comparer.DefaultInvariant.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@string, othr.@string);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(XmlNamespacesAliasElement left, XmlNamespacesAliasElement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static XmlNamespacesAliasElement FromMutable(ScriptDom.XmlNamespacesAliasElement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.XmlNamespacesAliasElement)) { throw new NotImplementedException("Unexpected subtype of XmlNamespacesAliasElement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlNamespacesAliasElement(
                identifier: ImmutableDom.Identifier.FromMutable(fragment.Identifier),
                @string: ImmutableDom.StringLiteral.FromMutable(fragment.String)
            );
        }
    
    }

}
