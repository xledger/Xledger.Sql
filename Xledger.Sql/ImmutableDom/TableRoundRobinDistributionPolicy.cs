using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableRoundRobinDistributionPolicy : TableDistributionPolicy, IEquatable<TableRoundRobinDistributionPolicy> {
        public TableRoundRobinDistributionPolicy() {

        }
    
        public ScriptDom.TableRoundRobinDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.TableRoundRobinDistributionPolicy();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableRoundRobinDistributionPolicy);
        } 
        
        public bool Equals(TableRoundRobinDistributionPolicy other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) {
            return EqualityComparer<TableRoundRobinDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) {
            return !(left == right);
        }
    
        public static TableRoundRobinDistributionPolicy FromMutable(ScriptDom.TableRoundRobinDistributionPolicy fragment) {
            return (TableRoundRobinDistributionPolicy)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
