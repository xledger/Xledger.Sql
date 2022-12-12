using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectNameOrValueExpression : TSqlFragment, IEquatable<SchemaObjectNameOrValueExpression> {
        SchemaObjectName schemaObjectName;
        ValueExpression valueExpression;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public ValueExpression ValueExpression => valueExpression;
    
        public SchemaObjectNameOrValueExpression(SchemaObjectName schemaObjectName = null, ValueExpression valueExpression = null) {
            this.schemaObjectName = schemaObjectName;
            this.valueExpression = valueExpression;
        }
    
        public ScriptDom.SchemaObjectNameOrValueExpression ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectNameOrValueExpression();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            ret.ValueExpression = (ScriptDom.ValueExpression)valueExpression.ToMutable();
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
    
    }

}
