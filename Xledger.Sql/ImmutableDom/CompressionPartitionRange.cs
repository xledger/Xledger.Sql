using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CompressionPartitionRange : TSqlFragment, IEquatable<CompressionPartitionRange> {
        protected ScalarExpression from;
        protected ScalarExpression to;
    
        public ScalarExpression From => from;
        public ScalarExpression To => to;
    
        public CompressionPartitionRange(ScalarExpression from = null, ScalarExpression to = null) {
            this.from = from;
            this.to = to;
        }
    
        public ScriptDom.CompressionPartitionRange ToMutableConcrete() {
            var ret = new ScriptDom.CompressionPartitionRange();
            ret.From = (ScriptDom.ScalarExpression)from?.ToMutable();
            ret.To = (ScriptDom.ScalarExpression)to?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(from is null)) {
                h = h * 23 + from.GetHashCode();
            }
            if (!(to is null)) {
                h = h * 23 + to.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CompressionPartitionRange);
        } 
        
        public bool Equals(CompressionPartitionRange other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.To, to)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CompressionPartitionRange left, CompressionPartitionRange right) {
            return EqualityComparer<CompressionPartitionRange>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CompressionPartitionRange left, CompressionPartitionRange right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CompressionPartitionRange)that;
            compare = Comparer.DefaultInvariant.Compare(this.from, othr.from);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.to, othr.to);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CompressionPartitionRange left, CompressionPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CompressionPartitionRange left, CompressionPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CompressionPartitionRange left, CompressionPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CompressionPartitionRange left, CompressionPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CompressionPartitionRange FromMutable(ScriptDom.CompressionPartitionRange fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CompressionPartitionRange)) { throw new NotImplementedException("Unexpected subtype of CompressionPartitionRange not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CompressionPartitionRange(
                from: ImmutableDom.ScalarExpression.FromMutable(fragment.From),
                to: ImmutableDom.ScalarExpression.FromMutable(fragment.To)
            );
        }
    
    }

}
