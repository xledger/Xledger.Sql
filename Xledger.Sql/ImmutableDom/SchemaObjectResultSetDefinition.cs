using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectResultSetDefinition : ResultSetDefinition, IEquatable<SchemaObjectResultSetDefinition> {
        protected SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public SchemaObjectResultSetDefinition(SchemaObjectName name = null, ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.name = name;
            this.resultSetType = resultSetType;
        }
    
        public new ScriptDom.SchemaObjectResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectResultSetDefinition();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaObjectResultSetDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.resultSetType, othr.resultSetType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaObjectResultSetDefinition left, SchemaObjectResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SchemaObjectResultSetDefinition FromMutable(ScriptDom.SchemaObjectResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SchemaObjectResultSetDefinition)) { throw new NotImplementedException("Unexpected subtype of SchemaObjectResultSetDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectResultSetDefinition(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                resultSetType: fragment.ResultSetType
            );
        }
    
    }

}
