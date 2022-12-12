using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderBulkInsertOption : BulkInsertOption, IEquatable<OrderBulkInsertOption> {
        IReadOnlyList<ColumnWithSortOrder> columns;
        bool isUnique = false;
    
        public IReadOnlyList<ColumnWithSortOrder> Columns => columns;
        public bool IsUnique => isUnique;
    
        public OrderBulkInsertOption(IReadOnlyList<ColumnWithSortOrder> columns = null, bool isUnique = false, ScriptDom.BulkInsertOptionKind optionKind = ScriptDom.BulkInsertOptionKind.None) {
            this.columns = columns is null ? ImmList<ColumnWithSortOrder>.Empty : ImmList<ColumnWithSortOrder>.FromList(columns);
            this.isUnique = isUnique;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OrderBulkInsertOption ToMutableConcrete() {
            var ret = new ScriptDom.OrderBulkInsertOption();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnWithSortOrder)c.ToMutable()));
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
    
    }

}
