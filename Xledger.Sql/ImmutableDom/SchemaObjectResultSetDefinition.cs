using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectResultSetDefinition : ResultSetDefinition, IEquatable<SchemaObjectResultSetDefinition> {
        protected SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public SchemaObjectResultSetDefinition(SchemaObjectName name = null, ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.name = name;
            this.resultSetType = resultSetType;
        }
    
        public ScriptDom.SchemaObjectResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectResultSetDefinition();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.ResultSetType = resultSetType;
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
            h = h * 23 + resultSetType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaObjectResultSetDefinition);
        } 
        
        public bool Equals(SchemaObjectResultSetDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ResultSetType>.Default.Equals(other.ResultSetType, resultSetType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) {
            return EqualityComparer<SchemaObjectResultSetDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) {
            return !(left == right);
        }
    
        public static SchemaObjectResultSetDefinition FromMutable(ScriptDom.SchemaObjectResultSetDefinition fragment) {
            return (SchemaObjectResultSetDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
