using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterXmlSchemaCollectionStatement : TSqlStatement, IEquatable<AlterXmlSchemaCollectionStatement> {
        protected SchemaObjectName name;
        protected ScalarExpression expression;
    
        public SchemaObjectName Name => name;
        public ScalarExpression Expression => expression;
    
        public AlterXmlSchemaCollectionStatement(SchemaObjectName name = null, ScalarExpression expression = null) {
            this.name = name;
            this.expression = expression;
        }
    
        public ScriptDom.AlterXmlSchemaCollectionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterXmlSchemaCollectionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
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
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterXmlSchemaCollectionStatement);
        } 
        
        public bool Equals(AlterXmlSchemaCollectionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) {
            return EqualityComparer<AlterXmlSchemaCollectionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterXmlSchemaCollectionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterXmlSchemaCollectionStatement left, AlterXmlSchemaCollectionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
