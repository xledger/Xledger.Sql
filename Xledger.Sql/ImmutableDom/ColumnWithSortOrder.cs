using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnWithSortOrder : TSqlFragment, IEquatable<ColumnWithSortOrder> {
        protected ColumnReferenceExpression column;
        protected ScriptDom.SortOrder sortOrder = ScriptDom.SortOrder.NotSpecified;
    
        public ColumnReferenceExpression Column => column;
        public ScriptDom.SortOrder SortOrder => sortOrder;
    
        public ColumnWithSortOrder(ColumnReferenceExpression column = null, ScriptDom.SortOrder sortOrder = ScriptDom.SortOrder.NotSpecified) {
            this.column = column;
            this.sortOrder = sortOrder;
        }
    
        public ScriptDom.ColumnWithSortOrder ToMutableConcrete() {
            var ret = new ScriptDom.ColumnWithSortOrder();
            ret.Column = (ScriptDom.ColumnReferenceExpression)column.ToMutable();
            ret.SortOrder = sortOrder;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            h = h * 23 + sortOrder.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnWithSortOrder);
        } 
        
        public bool Equals(ColumnWithSortOrder other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SortOrder>.Default.Equals(other.SortOrder, sortOrder)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnWithSortOrder left, ColumnWithSortOrder right) {
            return EqualityComparer<ColumnWithSortOrder>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnWithSortOrder left, ColumnWithSortOrder right) {
            return !(left == right);
        }
    
    }

}
