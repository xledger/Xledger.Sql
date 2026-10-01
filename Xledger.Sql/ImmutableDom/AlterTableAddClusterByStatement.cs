using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableAddClusterByStatement : AlterTableStatement, IEquatable<AlterTableAddClusterByStatement> {
        protected ClusterByTableOption clusterByOption;
    
        public ClusterByTableOption ClusterByOption => clusterByOption;
    
        public AlterTableAddClusterByStatement(ClusterByTableOption clusterByOption = null, SchemaObjectName schemaObjectName = null) {
            this.clusterByOption = clusterByOption;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableAddClusterByStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableAddClusterByStatement();
            ret.ClusterByOption = (ScriptDom.ClusterByTableOption)clusterByOption?.ToMutable();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(clusterByOption is null)) {
                h = h * 23 + clusterByOption.GetHashCode();
            }
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableAddClusterByStatement);
        } 
        
        public bool Equals(AlterTableAddClusterByStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ClusterByTableOption>.Default.Equals(other.ClusterByOption, clusterByOption)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) {
            return EqualityComparer<AlterTableAddClusterByStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableAddClusterByStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.clusterByOption, othr.clusterByOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableAddClusterByStatement left, AlterTableAddClusterByStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableAddClusterByStatement FromMutable(ScriptDom.AlterTableAddClusterByStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterTableAddClusterByStatement)) { throw new NotImplementedException("Unexpected subtype of AlterTableAddClusterByStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAddClusterByStatement(
                clusterByOption: ImmutableDom.ClusterByTableOption.FromMutable(fragment.ClusterByOption),
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName)
            );
        }
    
    }

}
