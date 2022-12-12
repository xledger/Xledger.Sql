using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateTextStatement : TextModificationStatement, IEquatable<UpdateTextStatement> {
        ScalarExpression insertOffset;
        ScalarExpression deleteLength;
        ColumnReferenceExpression sourceColumn;
        ValueExpression sourceParameter;
    
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
            ret.InsertOffset = (ScriptDom.ScalarExpression)insertOffset.ToMutable();
            ret.DeleteLength = (ScriptDom.ScalarExpression)deleteLength.ToMutable();
            ret.SourceColumn = (ScriptDom.ColumnReferenceExpression)sourceColumn.ToMutable();
            ret.SourceParameter = (ScriptDom.ValueExpression)sourceParameter.ToMutable();
            ret.Bulk = bulk;
            ret.Column = (ScriptDom.ColumnReferenceExpression)column.ToMutable();
            ret.TextId = (ScriptDom.ValueExpression)textId.ToMutable();
            ret.Timestamp = (ScriptDom.Literal)timestamp.ToMutable();
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
    
    }

}
