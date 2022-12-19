using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InsertMergeAction : MergeAction, IEquatable<InsertMergeAction> {
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected ValuesInsertSource source;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public ValuesInsertSource Source => source;
    
        public InsertMergeAction(IReadOnlyList<ColumnReferenceExpression> columns = null, ValuesInsertSource source = null) {
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
            this.source = source;
        }
    
        public ScriptDom.InsertMergeAction ToMutableConcrete() {
            var ret = new ScriptDom.InsertMergeAction();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.Source = (ScriptDom.ValuesInsertSource)source?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            if (!(source is null)) {
                h = h * 23 + source.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InsertMergeAction);
        } 
        
        public bool Equals(InsertMergeAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ValuesInsertSource>.Default.Equals(other.Source, source)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InsertMergeAction left, InsertMergeAction right) {
            return EqualityComparer<InsertMergeAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InsertMergeAction left, InsertMergeAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InsertMergeAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.source, othr.source);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (InsertMergeAction left, InsertMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InsertMergeAction left, InsertMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InsertMergeAction left, InsertMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InsertMergeAction left, InsertMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static InsertMergeAction FromMutable(ScriptDom.InsertMergeAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.InsertMergeAction)) { throw new NotImplementedException("Unexpected subtype of InsertMergeAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertMergeAction(
                columns: fragment.Columns.SelectList(ImmutableDom.ColumnReferenceExpression.FromMutable),
                source: ImmutableDom.ValuesInsertSource.FromMutable(fragment.Source)
            );
        }
    
    }

}
