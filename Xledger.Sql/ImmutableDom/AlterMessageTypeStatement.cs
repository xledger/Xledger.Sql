using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterMessageTypeStatement : MessageTypeStatementBase, IEquatable<AlterMessageTypeStatement> {
        public AlterMessageTypeStatement(Identifier name = null, ScriptDom.MessageValidationMethod validationMethod = ScriptDom.MessageValidationMethod.NotSpecified, SchemaObjectName xmlSchemaCollectionName = null) {
            this.name = name;
            this.validationMethod = validationMethod;
            this.xmlSchemaCollectionName = xmlSchemaCollectionName;
        }
    
        public ScriptDom.AlterMessageTypeStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterMessageTypeStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ValidationMethod = validationMethod;
            ret.XmlSchemaCollectionName = (ScriptDom.SchemaObjectName)xmlSchemaCollectionName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + validationMethod.GetHashCode();
            if (!(xmlSchemaCollectionName is null)) {
                h = h * 23 + xmlSchemaCollectionName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterMessageTypeStatement);
        } 
        
        public bool Equals(AlterMessageTypeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MessageValidationMethod>.Default.Equals(other.ValidationMethod, validationMethod)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.XmlSchemaCollectionName, xmlSchemaCollectionName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterMessageTypeStatement left, AlterMessageTypeStatement right) {
            return EqualityComparer<AlterMessageTypeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterMessageTypeStatement left, AlterMessageTypeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterMessageTypeStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.validationMethod, othr.validationMethod);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.xmlSchemaCollectionName, othr.xmlSchemaCollectionName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterMessageTypeStatement left, AlterMessageTypeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterMessageTypeStatement left, AlterMessageTypeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterMessageTypeStatement left, AlterMessageTypeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterMessageTypeStatement left, AlterMessageTypeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterMessageTypeStatement FromMutable(ScriptDom.AlterMessageTypeStatement fragment) {
            return (AlterMessageTypeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
