using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WriteTextStatement : TextModificationStatement, IEquatable<WriteTextStatement> {
        protected ValueExpression sourceParameter;
    
        public ValueExpression SourceParameter => sourceParameter;
    
        public WriteTextStatement(ValueExpression sourceParameter = null, bool bulk = false, ColumnReferenceExpression column = null, ValueExpression textId = null, Literal timestamp = null, bool withLog = false) {
            this.sourceParameter = sourceParameter;
            this.bulk = bulk;
            this.column = column;
            this.textId = textId;
            this.timestamp = timestamp;
            this.withLog = withLog;
        }
    
        public ScriptDom.WriteTextStatement ToMutableConcrete() {
            var ret = new ScriptDom.WriteTextStatement();
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
            return Equals(obj as WriteTextStatement);
        } 
        
        public bool Equals(WriteTextStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(WriteTextStatement left, WriteTextStatement right) {
            return EqualityComparer<WriteTextStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WriteTextStatement left, WriteTextStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WriteTextStatement)that;
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
        public static bool operator < (WriteTextStatement left, WriteTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WriteTextStatement left, WriteTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WriteTextStatement left, WriteTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WriteTextStatement left, WriteTextStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static WriteTextStatement FromMutable(ScriptDom.WriteTextStatement fragment) {
            return (WriteTextStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
