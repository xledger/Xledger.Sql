using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
            ret.ShardingColumn = (ScriptDom.Identifier)shardingColumn.ToMutable();
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
    
        public static ExternalTableShardedDistributionPolicy FromMutable(ScriptDom.ExternalTableShardedDistributionPolicy fragment) {
            return (ExternalTableShardedDistributionPolicy)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
