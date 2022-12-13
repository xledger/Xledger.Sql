using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableClusteredIndexType : TableIndexType, IEquatable<TableClusteredIndexType> {
        protected IReadOnlyList<ColumnWithSortOrder> columns;
        protected bool columnStore = false;
        protected IReadOnlyList<ColumnReferenceExpression> orderedColumns;
    
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public bool ColumnStore => columnStore;
        public IReadOnlyList<ColumnReferenceExpression> OrderedColumns => orderedColumns;
    
        public TableClusteredIndexType(IReadOnlyList<ColumnWithSortOrder> columns = null, bool columnStore = false, IReadOnlyList<ColumnReferenceExpression> orderedColumns = null) {
            this.columns = columns is null ? ImmList<ColumnWithSortOrder>.Empty : ImmList<ColumnWithSortOrder>.FromList(columns);
            this.columnStore = columnStore;
            this.orderedColumns = orderedColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(orderedColumns);
        }
    
        public ScriptDom.TableClusteredIndexType ToMutableConcrete() {
            var ret = new ScriptDom.TableClusteredIndexType();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnWithSortOrder)c.ToMutable()));
            ret.ColumnStore = columnStore;
            ret.OrderedColumns.AddRange(orderedColumns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + columnStore.GetHashCode();
            h = h * 23 + orderedColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableClusteredIndexType);
        } 
        
        public bool Equals(TableClusteredIndexType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnWithSortOrder>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ColumnStore, columnStore)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.OrderedColumns, orderedColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableClusteredIndexType left, TableClusteredIndexType right) {
            return EqualityComparer<TableClusteredIndexType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableClusteredIndexType left, TableClusteredIndexType right) {
            return !(left == right);
        }
    
        public static TableClusteredIndexType FromMutable(ScriptDom.TableClusteredIndexType fragment) {
            return (TableClusteredIndexType)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
