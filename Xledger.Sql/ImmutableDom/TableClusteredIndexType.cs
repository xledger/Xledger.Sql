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
            this.columns = ImmList<ColumnWithSortOrder>.FromList(columns);
            this.columnStore = columnStore;
            this.orderedColumns = ImmList<ColumnReferenceExpression>.FromList(orderedColumns);
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableClusteredIndexType)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnStore, othr.columnStore);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.orderedColumns, othr.orderedColumns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableClusteredIndexType left, TableClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableClusteredIndexType left, TableClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableClusteredIndexType left, TableClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableClusteredIndexType left, TableClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
