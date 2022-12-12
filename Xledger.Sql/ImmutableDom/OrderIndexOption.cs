using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderIndexOption : IndexOption, IEquatable<OrderIndexOption> {
        IReadOnlyList<ColumnReferenceExpression> columns;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public OrderIndexOption(IReadOnlyList<ColumnReferenceExpression> columns = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OrderIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.OrderIndexOption();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OrderIndexOption);
        } 
        
        public bool Equals(OrderIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OrderIndexOption left, OrderIndexOption right) {
            return EqualityComparer<OrderIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OrderIndexOption left, OrderIndexOption right) {
            return !(left == right);
        }
    
    }

}
