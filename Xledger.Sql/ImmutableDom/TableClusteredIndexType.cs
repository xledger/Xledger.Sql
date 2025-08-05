using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            this.columns = columns.ToImmArray<ColumnWithSortOrder>();
            this.columnStore = columnStore;
            this.orderedColumns = orderedColumns.ToImmArray<ColumnReferenceExpression>();
        }
    
        public ScriptDom.TableClusteredIndexType ToMutableConcrete() {
            var ret = new ScriptDom.TableClusteredIndexType();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnWithSortOrder)c?.ToMutable()));
            ret.ColumnStore = columnStore;
            ret.OrderedColumns.AddRange(orderedColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
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
    
        public static TableClusteredIndexType FromMutable(ScriptDom.TableClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TableClusteredIndexType)) { throw new NotImplementedException("Unexpected subtype of TableClusteredIndexType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableClusteredIndexType(
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnWithSortOrder.FromMutable),
                columnStore: fragment.ColumnStore,
                orderedColumns: fragment.OrderedColumns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable)
            );
        }
    
    }

}
