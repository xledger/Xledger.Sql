using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReadTextStatement : TSqlStatement, IEquatable<ReadTextStatement> {
        ColumnReferenceExpression column;
        ValueExpression textPointer;
        ValueExpression offset;
        ValueExpression size;
        bool holdLock = false;
    
        public ColumnReferenceExpression Column => column;
        public ValueExpression TextPointer => textPointer;
        public ValueExpression Offset => offset;
        public ValueExpression Size => size;
        public bool HoldLock => holdLock;
    
        public ReadTextStatement(ColumnReferenceExpression column = null, ValueExpression textPointer = null, ValueExpression offset = null, ValueExpression size = null, bool holdLock = false) {
            this.column = column;
            this.textPointer = textPointer;
            this.offset = offset;
            this.size = size;
            this.holdLock = holdLock;
        }
    
        public ScriptDom.ReadTextStatement ToMutableConcrete() {
            var ret = new ScriptDom.ReadTextStatement();
            ret.Column = (ScriptDom.ColumnReferenceExpression)column.ToMutable();
            ret.TextPointer = (ScriptDom.ValueExpression)textPointer.ToMutable();
            ret.Offset = (ScriptDom.ValueExpression)offset.ToMutable();
            ret.Size = (ScriptDom.ValueExpression)size.ToMutable();
            ret.HoldLock = holdLock;
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
            if (!(textPointer is null)) {
                h = h * 23 + textPointer.GetHashCode();
            }
            if (!(offset is null)) {
                h = h * 23 + offset.GetHashCode();
            }
            if (!(size is null)) {
                h = h * 23 + size.GetHashCode();
            }
            h = h * 23 + holdLock.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReadTextStatement);
        } 
        
        public bool Equals(ReadTextStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.TextPointer, textPointer)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Offset, offset)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Size, size)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.HoldLock, holdLock)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ReadTextStatement left, ReadTextStatement right) {
            return EqualityComparer<ReadTextStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReadTextStatement left, ReadTextStatement right) {
            return !(left == right);
        }
    
    }

}