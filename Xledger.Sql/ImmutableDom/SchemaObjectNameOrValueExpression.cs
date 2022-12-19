using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectNameOrValueExpression : TSqlFragment, IEquatable<SchemaObjectNameOrValueExpression> {
        protected SchemaObjectName schemaObjectName;
        protected ValueExpression valueExpression;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public ValueExpression ValueExpression => valueExpression;
    
        public SchemaObjectNameOrValueExpression(SchemaObjectName schemaObjectName = null, ValueExpression valueExpression = null) {
            this.schemaObjectName = schemaObjectName;
            this.valueExpression = valueExpression;
        }
    
        public ScriptDom.SchemaObjectNameOrValueExpression ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectNameOrValueExpression();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.ValueExpression = (ScriptDom.ValueExpression)valueExpression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            if (!(valueExpression is null)) {
                h = h * 23 + valueExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaObjectNameOrValueExpression);
        } 
        
        public bool Equals(SchemaObjectNameOrValueExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ValueExpression, valueExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) {
            return EqualityComparer<SchemaObjectNameOrValueExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaObjectNameOrValueExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.valueExpression, othr.valueExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaObjectNameOrValueExpression left, SchemaObjectNameOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SchemaObjectNameOrValueExpression FromMutable(ScriptDom.SchemaObjectNameOrValueExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SchemaObjectNameOrValueExpression)) { throw new NotImplementedException("Unexpected subtype of SchemaObjectNameOrValueExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectNameOrValueExpression(
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName),
                valueExpression: ImmutableDom.ValueExpression.FromMutable(fragment.ValueExpression)
            );
        }
    
    }

}
