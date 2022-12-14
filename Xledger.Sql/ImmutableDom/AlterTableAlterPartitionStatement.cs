using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableAlterPartitionStatement : AlterTableStatement, IEquatable<AlterTableAlterPartitionStatement> {
        protected ScalarExpression boundaryValue;
        protected bool isSplit = false;
    
        public ScalarExpression BoundaryValue => boundaryValue;
        public bool IsSplit => isSplit;
    
        public AlterTableAlterPartitionStatement(ScalarExpression boundaryValue = null, bool isSplit = false, SchemaObjectName schemaObjectName = null) {
            this.boundaryValue = boundaryValue;
            this.isSplit = isSplit;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableAlterPartitionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableAlterPartitionStatement();
            ret.BoundaryValue = (ScriptDom.ScalarExpression)boundaryValue?.ToMutable();
            ret.IsSplit = isSplit;
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(boundaryValue is null)) {
                h = h * 23 + boundaryValue.GetHashCode();
            }
            h = h * 23 + isSplit.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableAlterPartitionStatement);
        } 
        
        public bool Equals(AlterTableAlterPartitionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.BoundaryValue, boundaryValue)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSplit, isSplit)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) {
            return EqualityComparer<AlterTableAlterPartitionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableAlterPartitionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.boundaryValue, othr.boundaryValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isSplit, othr.isSplit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableAlterPartitionStatement left, AlterTableAlterPartitionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableAlterPartitionStatement FromMutable(ScriptDom.AlterTableAlterPartitionStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterTableAlterPartitionStatement)) { throw new NotImplementedException("Unexpected subtype of AlterTableAlterPartitionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAlterPartitionStatement(
                boundaryValue: ImmutableDom.ScalarExpression.FromMutable(fragment.BoundaryValue),
                isSplit: fragment.IsSplit,
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName)
            );
        }
    
    }

}
