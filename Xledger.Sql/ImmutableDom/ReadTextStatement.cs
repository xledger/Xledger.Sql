using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReadTextStatement : TSqlStatement, IEquatable<ReadTextStatement> {
        protected ColumnReferenceExpression column;
        protected ValueExpression textPointer;
        protected ValueExpression offset;
        protected ValueExpression size;
        protected bool holdLock = false;
    
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
            ret.Column = (ScriptDom.ColumnReferenceExpression)column?.ToMutable();
            ret.TextPointer = (ScriptDom.ValueExpression)textPointer?.ToMutable();
            ret.Offset = (ScriptDom.ValueExpression)offset?.ToMutable();
            ret.Size = (ScriptDom.ValueExpression)size?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ReadTextStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.column, othr.column);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.textPointer, othr.textPointer);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.offset, othr.offset);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.size, othr.size);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.holdLock, othr.holdLock);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ReadTextStatement left, ReadTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ReadTextStatement left, ReadTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ReadTextStatement left, ReadTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ReadTextStatement left, ReadTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ReadTextStatement FromMutable(ScriptDom.ReadTextStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ReadTextStatement)) { throw new NotImplementedException("Unexpected subtype of ReadTextStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReadTextStatement(
                column: ImmutableDom.ColumnReferenceExpression.FromMutable(fragment.Column),
                textPointer: ImmutableDom.ValueExpression.FromMutable(fragment.TextPointer),
                offset: ImmutableDom.ValueExpression.FromMutable(fragment.Offset),
                size: ImmutableDom.ValueExpression.FromMutable(fragment.Size),
                holdLock: fragment.HoldLock
            );
        }
    
    }

}
