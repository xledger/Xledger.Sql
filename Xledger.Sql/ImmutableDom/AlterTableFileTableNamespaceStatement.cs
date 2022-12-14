using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableFileTableNamespaceStatement : AlterTableStatement, IEquatable<AlterTableFileTableNamespaceStatement> {
        protected bool isEnable = false;
    
        public bool IsEnable => isEnable;
    
        public AlterTableFileTableNamespaceStatement(bool isEnable = false, SchemaObjectName schemaObjectName = null) {
            this.isEnable = isEnable;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableFileTableNamespaceStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableFileTableNamespaceStatement();
            ret.IsEnable = isEnable;
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isEnable.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableFileTableNamespaceStatement);
        } 
        
        public bool Equals(AlterTableFileTableNamespaceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsEnable, isEnable)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableFileTableNamespaceStatement left, AlterTableFileTableNamespaceStatement right) {
            return EqualityComparer<AlterTableFileTableNamespaceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableFileTableNamespaceStatement left, AlterTableFileTableNamespaceStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableFileTableNamespaceStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.isEnable, othr.isEnable);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterTableFileTableNamespaceStatement FromMutable(ScriptDom.AlterTableFileTableNamespaceStatement fragment) {
            return (AlterTableFileTableNamespaceStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
