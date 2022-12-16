using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlDataTypeReference : DataTypeReference, IEquatable<XmlDataTypeReference> {
        protected ScriptDom.XmlDataTypeOption xmlDataTypeOption = ScriptDom.XmlDataTypeOption.None;
        protected SchemaObjectName xmlSchemaCollection;
    
        public ScriptDom.XmlDataTypeOption XmlDataTypeOption => xmlDataTypeOption;
        public SchemaObjectName XmlSchemaCollection => xmlSchemaCollection;
    
        public XmlDataTypeReference(ScriptDom.XmlDataTypeOption xmlDataTypeOption = ScriptDom.XmlDataTypeOption.None, SchemaObjectName xmlSchemaCollection = null, SchemaObjectName name = null) {
            this.xmlDataTypeOption = xmlDataTypeOption;
            this.xmlSchemaCollection = xmlSchemaCollection;
            this.name = name;
        }
    
        public ScriptDom.XmlDataTypeReference ToMutableConcrete() {
            var ret = new ScriptDom.XmlDataTypeReference();
            ret.XmlDataTypeOption = xmlDataTypeOption;
            ret.XmlSchemaCollection = (ScriptDom.SchemaObjectName)xmlSchemaCollection?.ToMutable();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + xmlDataTypeOption.GetHashCode();
            if (!(xmlSchemaCollection is null)) {
                h = h * 23 + xmlSchemaCollection.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlDataTypeReference);
        } 
        
        public bool Equals(XmlDataTypeReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.XmlDataTypeOption>.Default.Equals(other.XmlDataTypeOption, xmlDataTypeOption)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.XmlSchemaCollection, xmlSchemaCollection)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlDataTypeReference left, XmlDataTypeReference right) {
            return EqualityComparer<XmlDataTypeReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlDataTypeReference left, XmlDataTypeReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (XmlDataTypeReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.xmlDataTypeOption, othr.xmlDataTypeOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.xmlSchemaCollection, othr.xmlSchemaCollection);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (XmlDataTypeReference left, XmlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(XmlDataTypeReference left, XmlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (XmlDataTypeReference left, XmlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(XmlDataTypeReference left, XmlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
