using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableShardedDistributionPolicy : ExternalTableDistributionPolicy, IEquatable<ExternalTableShardedDistributionPolicy> {
        protected Identifier shardingColumn;
    
        public Identifier ShardingColumn => shardingColumn;
    
        public ExternalTableShardedDistributionPolicy(Identifier shardingColumn = null) {
            this.shardingColumn = shardingColumn;
        }
    
        public ScriptDom.ExternalTableShardedDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableShardedDistributionPolicy();
            ret.ShardingColumn = (ScriptDom.Identifier)shardingColumn?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(shardingColumn is null)) {
                h = h * 23 + shardingColumn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalTableShardedDistributionPolicy);
        } 
        
        public bool Equals(ExternalTableShardedDistributionPolicy other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ShardingColumn, shardingColumn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) {
            return EqualityComparer<ExternalTableShardedDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalTableShardedDistributionPolicy)that;
            compare = Comparer.DefaultInvariant.Compare(this.shardingColumn, othr.shardingColumn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalTableShardedDistributionPolicy left, ExternalTableShardedDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalTableShardedDistributionPolicy FromMutable(ScriptDom.ExternalTableShardedDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalTableShardedDistributionPolicy)) { throw new NotImplementedException("Unexpected subtype of ExternalTableShardedDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableShardedDistributionPolicy(
                shardingColumn: ImmutableDom.Identifier.FromMutable(fragment.ShardingColumn)
            );
        }
    
    }

}
