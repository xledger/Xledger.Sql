using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StatisticsPartitionRange : TSqlFragment, IEquatable<StatisticsPartitionRange> {
        protected IntegerLiteral from;
        protected IntegerLiteral to;
    
        public IntegerLiteral From => from;
        public IntegerLiteral To => to;
    
        public StatisticsPartitionRange(IntegerLiteral from = null, IntegerLiteral to = null) {
            this.from = from;
            this.to = to;
        }
    
        public ScriptDom.StatisticsPartitionRange ToMutableConcrete() {
            var ret = new ScriptDom.StatisticsPartitionRange();
            ret.From = (ScriptDom.IntegerLiteral)from.ToMutable();
            ret.To = (ScriptDom.IntegerLiteral)to.ToMutable();
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
            return Equals(obj as StatisticsPartitionRange);
        } 
        
        public bool Equals(StatisticsPartitionRange other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.To, to)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StatisticsPartitionRange left, StatisticsPartitionRange right) {
            return EqualityComparer<StatisticsPartitionRange>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StatisticsPartitionRange left, StatisticsPartitionRange right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (StatisticsPartitionRange)that;
            compare = Comparer.DefaultInvariant.Compare(this.from, othr.from);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.to, othr.to);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (StatisticsPartitionRange left, StatisticsPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(StatisticsPartitionRange left, StatisticsPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (StatisticsPartitionRange left, StatisticsPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(StatisticsPartitionRange left, StatisticsPartitionRange right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
