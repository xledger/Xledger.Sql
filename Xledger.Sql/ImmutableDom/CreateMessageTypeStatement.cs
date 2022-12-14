using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateMessageTypeStatement : MessageTypeStatementBase, IEquatable<CreateMessageTypeStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateMessageTypeStatement(Identifier owner = null, Identifier name = null, ScriptDom.MessageValidationMethod validationMethod = ScriptDom.MessageValidationMethod.NotSpecified, SchemaObjectName xmlSchemaCollectionName = null) {
            this.owner = owner;
            this.name = name;
            this.validationMethod = validationMethod;
            this.xmlSchemaCollectionName = xmlSchemaCollectionName;
        }
    
        public ScriptDom.CreateMessageTypeStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateMessageTypeStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
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
            return Equals(obj as CreateMessageTypeStatement);
        } 
        
        public bool Equals(CreateMessageTypeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
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
        
        public static bool operator ==(CreateMessageTypeStatement left, CreateMessageTypeStatement right) {
            return EqualityComparer<CreateMessageTypeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateMessageTypeStatement left, CreateMessageTypeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateMessageTypeStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.validationMethod, othr.validationMethod);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.xmlSchemaCollectionName, othr.xmlSchemaCollectionName);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static CreateMessageTypeStatement FromMutable(ScriptDom.CreateMessageTypeStatement fragment) {
            return (CreateMessageTypeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
