using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableSwitchStatement : AlterTableStatement, IEquatable<AlterTableSwitchStatement> {
        protected ScalarExpression sourcePartitionNumber;
        protected ScalarExpression targetPartitionNumber;
        protected SchemaObjectName targetTable;
        protected IReadOnlyList<TableSwitchOption> options;
    
        public ScalarExpression SourcePartitionNumber => sourcePartitionNumber;
        public ScalarExpression TargetPartitionNumber => targetPartitionNumber;
        public SchemaObjectName TargetTable => targetTable;
        public IReadOnlyList<TableSwitchOption> Options => options;
    
        public AlterTableSwitchStatement(ScalarExpression sourcePartitionNumber = null, ScalarExpression targetPartitionNumber = null, SchemaObjectName targetTable = null, IReadOnlyList<TableSwitchOption> options = null, SchemaObjectName schemaObjectName = null) {
            this.sourcePartitionNumber = sourcePartitionNumber;
            this.targetPartitionNumber = targetPartitionNumber;
            this.targetTable = targetTable;
            this.options = ImmList<TableSwitchOption>.FromList(options);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableSwitchStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableSwitchStatement();
            ret.SourcePartitionNumber = (ScriptDom.ScalarExpression)sourcePartitionNumber?.ToMutable();
            ret.TargetPartitionNumber = (ScriptDom.ScalarExpression)targetPartitionNumber?.ToMutable();
            ret.TargetTable = (ScriptDom.SchemaObjectName)targetTable?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableSwitchOption)c?.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(sourcePartitionNumber is null)) {
                h = h * 23 + sourcePartitionNumber.GetHashCode();
            }
            if (!(targetPartitionNumber is null)) {
                h = h * 23 + targetPartitionNumber.GetHashCode();
            }
            if (!(targetTable is null)) {
                h = h * 23 + targetTable.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableSwitchStatement);
        } 
        
        public bool Equals(AlterTableSwitchStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SourcePartitionNumber, sourcePartitionNumber)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.TargetPartitionNumber, targetPartitionNumber)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TargetTable, targetTable)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TableSwitchOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableSwitchStatement left, AlterTableSwitchStatement right) {
            return EqualityComparer<AlterTableSwitchStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableSwitchStatement left, AlterTableSwitchStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableSwitchStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.sourcePartitionNumber, othr.sourcePartitionNumber);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.targetPartitionNumber, othr.targetPartitionNumber);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.targetTable, othr.targetTable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterTableSwitchStatement left, AlterTableSwitchStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableSwitchStatement left, AlterTableSwitchStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableSwitchStatement left, AlterTableSwitchStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableSwitchStatement left, AlterTableSwitchStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableSwitchStatement FromMutable(ScriptDom.AlterTableSwitchStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterTableSwitchStatement)) { throw new NotImplementedException("Unexpected subtype of AlterTableSwitchStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableSwitchStatement(
                sourcePartitionNumber: ImmutableDom.ScalarExpression.FromMutable(fragment.SourcePartitionNumber),
                targetPartitionNumber: ImmutableDom.ScalarExpression.FromMutable(fragment.TargetPartitionNumber),
                targetTable: ImmutableDom.SchemaObjectName.FromMutable(fragment.TargetTable),
                options: fragment.Options.SelectList(ImmutableDom.TableSwitchOption.FromMutable),
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName)
            );
        }
    
    }

}
