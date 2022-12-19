using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateTextStatement : TextModificationStatement, IEquatable<UpdateTextStatement> {
        protected ScalarExpression insertOffset;
        protected ScalarExpression deleteLength;
        protected ColumnReferenceExpression sourceColumn;
        protected ValueExpression sourceParameter;
    
        public ScalarExpression InsertOffset => insertOffset;
        public ScalarExpression DeleteLength => deleteLength;
        public ColumnReferenceExpression SourceColumn => sourceColumn;
        public ValueExpression SourceParameter => sourceParameter;
    
        public UpdateTextStatement(ScalarExpression insertOffset = null, ScalarExpression deleteLength = null, ColumnReferenceExpression sourceColumn = null, ValueExpression sourceParameter = null, bool bulk = false, ColumnReferenceExpression column = null, ValueExpression textId = null, Literal timestamp = null, bool withLog = false) {
            this.insertOffset = insertOffset;
            this.deleteLength = deleteLength;
            this.sourceColumn = sourceColumn;
            this.sourceParameter = sourceParameter;
            this.bulk = bulk;
            this.column = column;
            this.textId = textId;
            this.timestamp = timestamp;
            this.withLog = withLog;
        }
    
        public ScriptDom.UpdateTextStatement ToMutableConcrete() {
            var ret = new ScriptDom.UpdateTextStatement();
            ret.InsertOffset = (ScriptDom.ScalarExpression)insertOffset?.ToMutable();
            ret.DeleteLength = (ScriptDom.ScalarExpression)deleteLength?.ToMutable();
            ret.SourceColumn = (ScriptDom.ColumnReferenceExpression)sourceColumn?.ToMutable();
            ret.SourceParameter = (ScriptDom.ValueExpression)sourceParameter?.ToMutable();
            ret.Bulk = bulk;
            ret.Column = (ScriptDom.ColumnReferenceExpression)column?.ToMutable();
            ret.TextId = (ScriptDom.ValueExpression)textId?.ToMutable();
            ret.Timestamp = (ScriptDom.Literal)timestamp?.ToMutable();
            ret.WithLog = withLog;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(insertOffset is null)) {
                h = h * 23 + insertOffset.GetHashCode();
            }
            if (!(deleteLength is null)) {
                h = h * 23 + deleteLength.GetHashCode();
            }
            if (!(sourceColumn is null)) {
                h = h * 23 + sourceColumn.GetHashCode();
            }
            if (!(sourceParameter is null)) {
                h = h * 23 + sourceParameter.GetHashCode();
            }
            h = h * 23 + bulk.GetHashCode();
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            if (!(textId is null)) {
                h = h * 23 + textId.GetHashCode();
            }
            if (!(timestamp is null)) {
                h = h * 23 + timestamp.GetHashCode();
            }
            h = h * 23 + withLog.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateTextStatement);
        } 
        
        public bool Equals(UpdateTextStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.InsertOffset, insertOffset)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.DeleteLength, deleteLength)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.SourceColumn, sourceColumn)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.SourceParameter, sourceParameter)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Bulk, bulk)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.TextId, textId)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Timestamp, timestamp)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithLog, withLog)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateTextStatement left, UpdateTextStatement right) {
            return EqualityComparer<UpdateTextStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateTextStatement left, UpdateTextStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UpdateTextStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.insertOffset, othr.insertOffset);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.deleteLength, othr.deleteLength);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceColumn, othr.sourceColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceParameter, othr.sourceParameter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.bulk, othr.bulk);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.column, othr.column);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.textId, othr.textId);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.timestamp, othr.timestamp);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withLog, othr.withLog);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UpdateTextStatement left, UpdateTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UpdateTextStatement left, UpdateTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UpdateTextStatement left, UpdateTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UpdateTextStatement left, UpdateTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UpdateTextStatement FromMutable(ScriptDom.UpdateTextStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UpdateTextStatement)) { throw new NotImplementedException("Unexpected subtype of UpdateTextStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateTextStatement(
                insertOffset: ImmutableDom.ScalarExpression.FromMutable(fragment.InsertOffset),
                deleteLength: ImmutableDom.ScalarExpression.FromMutable(fragment.DeleteLength),
                sourceColumn: ImmutableDom.ColumnReferenceExpression.FromMutable(fragment.SourceColumn),
                sourceParameter: ImmutableDom.ValueExpression.FromMutable(fragment.SourceParameter),
                bulk: fragment.Bulk,
                column: ImmutableDom.ColumnReferenceExpression.FromMutable(fragment.Column),
                textId: ImmutableDom.ValueExpression.FromMutable(fragment.TextId),
                timestamp: ImmutableDom.Literal.FromMutable(fragment.Timestamp),
                withLog: fragment.WithLog
            );
        }
    
    }

}
