using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OrderIndexOption : IndexOption, IEquatable<OrderIndexOption> {
        protected IReadOnlyList<ColumnReferenceExpression> columns;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public OrderIndexOption(IReadOnlyList<ColumnReferenceExpression> columns = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OrderIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.OrderIndexOption();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OrderIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OrderIndexOption left, OrderIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OrderIndexOption left, OrderIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OrderIndexOption left, OrderIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OrderIndexOption left, OrderIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OrderIndexOption FromMutable(ScriptDom.OrderIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OrderIndexOption)) { throw new NotImplementedException("Unexpected subtype of OrderIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderIndexOption(
                columns: fragment.Columns.SelectList(ImmutableDom.ColumnReferenceExpression.FromMutable),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
