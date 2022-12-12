using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableDefinition : TSqlFragment, IEquatable<TableDefinition> {
        IReadOnlyList<ColumnDefinition> columnDefinitions;
        IReadOnlyList<ConstraintDefinition> tableConstraints;
        IReadOnlyList<IndexDefinition> indexes;
        SystemTimePeriodDefinition systemTimePeriod;
    
        public IReadOnlyList<ColumnDefinition> ColumnDefinitions => columnDefinitions;
        public IReadOnlyList<ConstraintDefinition> TableConstraints => tableConstraints;
        public IReadOnlyList<IndexDefinition> Indexes => indexes;
        public SystemTimePeriodDefinition SystemTimePeriod => systemTimePeriod;
    
        public TableDefinition(IReadOnlyList<ColumnDefinition> columnDefinitions = null, IReadOnlyList<ConstraintDefinition> tableConstraints = null, IReadOnlyList<IndexDefinition> indexes = null, SystemTimePeriodDefinition systemTimePeriod = null) {
            this.columnDefinitions = columnDefinitions is null ? ImmList<ColumnDefinition>.Empty : ImmList<ColumnDefinition>.FromList(columnDefinitions);
            this.tableConstraints = tableConstraints is null ? ImmList<ConstraintDefinition>.Empty : ImmList<ConstraintDefinition>.FromList(tableConstraints);
            this.indexes = indexes is null ? ImmList<IndexDefinition>.Empty : ImmList<IndexDefinition>.FromList(indexes);
            this.systemTimePeriod = systemTimePeriod;
        }
    
        public ScriptDom.TableDefinition ToMutableConcrete() {
            var ret = new ScriptDom.TableDefinition();
            ret.ColumnDefinitions.AddRange(columnDefinitions.Select(c => (ScriptDom.ColumnDefinition)c.ToMutable()));
            ret.TableConstraints.AddRange(tableConstraints.Select(c => (ScriptDom.ConstraintDefinition)c.ToMutable()));
            ret.Indexes.AddRange(indexes.Select(c => (ScriptDom.IndexDefinition)c.ToMutable()));
            ret.SystemTimePeriod = (ScriptDom.SystemTimePeriodDefinition)systemTimePeriod.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columnDefinitions.GetHashCode();
            h = h * 23 + tableConstraints.GetHashCode();
            h = h * 23 + indexes.GetHashCode();
            if (!(systemTimePeriod is null)) {
                h = h * 23 + systemTimePeriod.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableDefinition);
        } 
        
        public bool Equals(TableDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnDefinition>>.Default.Equals(other.ColumnDefinitions, columnDefinitions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ConstraintDefinition>>.Default.Equals(other.TableConstraints, tableConstraints)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexDefinition>>.Default.Equals(other.Indexes, indexes)) {
                return false;
            }
            if (!EqualityComparer<SystemTimePeriodDefinition>.Default.Equals(other.SystemTimePeriod, systemTimePeriod)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableDefinition left, TableDefinition right) {
            return EqualityComparer<TableDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableDefinition left, TableDefinition right) {
            return !(left == right);
        }
    
    }

}
