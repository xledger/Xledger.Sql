using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSensitivityClassificationStatement : SensitivityClassificationStatement, IEquatable<DropSensitivityClassificationStatement> {
        public DropSensitivityClassificationStatement(IReadOnlyList<ColumnReferenceExpression> columns = null) {
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
        }
    
        public ScriptDom.DropSensitivityClassificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSensitivityClassificationStatement();
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
            return Equals(obj as DropSensitivityClassificationStatement);
        } 
        
        public bool Equals(DropSensitivityClassificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) {
            return EqualityComparer<DropSensitivityClassificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropSensitivityClassificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropSensitivityClassificationStatement FromMutable(ScriptDom.DropSensitivityClassificationStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropSensitivityClassificationStatement)) { throw new NotImplementedException("Unexpected subtype of DropSensitivityClassificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSensitivityClassificationStatement(
                columns: fragment.Columns.SelectList(ImmutableDom.ColumnReferenceExpression.FromMutable)
            );
        }
    
    }

}
