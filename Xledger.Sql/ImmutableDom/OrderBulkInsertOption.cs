using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderBulkInsertOption : BulkInsertOption, IEquatable<OrderBulkInsertOption> {
        protected IReadOnlyList<ColumnWithSortOrder> columns;
        protected bool isUnique = false;
    
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public bool IsUnique => isUnique;
    
        public OrderBulkInsertOption(IReadOnlyList<ColumnWithSortOrder> columns = null, bool isUnique = false, ScriptDom.BulkInsertOptionKind optionKind = ScriptDom.BulkInsertOptionKind.None) {
            this.columns = ImmList<ColumnWithSortOrder>.FromList(columns);
            this.isUnique = isUnique;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.OrderBulkInsertOption ToMutableConcrete() {
            var ret = new ScriptDom.OrderBulkInsertOption();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnWithSortOrder)c?.ToMutable()));
            ret.IsUnique = isUnique;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + isUnique.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OrderBulkInsertOption);
        } 
        
        public bool Equals(OrderBulkInsertOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnWithSortOrder>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsUnique, isUnique)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BulkInsertOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OrderBulkInsertOption left, OrderBulkInsertOption right) {
            return EqualityComparer<OrderBulkInsertOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OrderBulkInsertOption left, OrderBulkInsertOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OrderBulkInsertOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isUnique, othr.isUnique);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OrderBulkInsertOption left, OrderBulkInsertOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OrderBulkInsertOption left, OrderBulkInsertOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OrderBulkInsertOption left, OrderBulkInsertOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OrderBulkInsertOption left, OrderBulkInsertOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OrderBulkInsertOption FromMutable(ScriptDom.OrderBulkInsertOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OrderBulkInsertOption)) { throw new NotImplementedException("Unexpected subtype of OrderBulkInsertOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderBulkInsertOption(
                columns: fragment.Columns.SelectList(ImmutableDom.ColumnWithSortOrder.FromMutable),
                isUnique: fragment.IsUnique,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
