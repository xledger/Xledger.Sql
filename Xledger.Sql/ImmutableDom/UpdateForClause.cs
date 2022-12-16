using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateForClause : ForClause, IEquatable<UpdateForClause> {
        protected IReadOnlyList<ColumnReferenceExpression> columns;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public UpdateForClause(IReadOnlyList<ColumnReferenceExpression> columns = null) {
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
        }
    
        public ScriptDom.UpdateForClause ToMutableConcrete() {
            var ret = new ScriptDom.UpdateForClause();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateForClause);
        } 
        
        public bool Equals(UpdateForClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateForClause left, UpdateForClause right) {
            return EqualityComparer<UpdateForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateForClause left, UpdateForClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UpdateForClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UpdateForClause left, UpdateForClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UpdateForClause left, UpdateForClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UpdateForClause left, UpdateForClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UpdateForClause left, UpdateForClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
