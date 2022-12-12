using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RowValue : TSqlFragment, IEquatable<RowValue> {
        protected IReadOnlyList<ScalarExpression> columnValues;
    
        public IReadOnlyList<ScalarExpression> ColumnValues => columnValues;
    
        public RowValue(IReadOnlyList<ScalarExpression> columnValues = null) {
            this.columnValues = columnValues is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(columnValues);
        }
    
        public ScriptDom.RowValue ToMutableConcrete() {
            var ret = new ScriptDom.RowValue();
            ret.ColumnValues.AddRange(columnValues.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columnValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RowValue);
        } 
        
        public bool Equals(RowValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.ColumnValues, columnValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RowValue left, RowValue right) {
            return EqualityComparer<RowValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RowValue left, RowValue right) {
            return !(left == right);
        }
    
    }

}
