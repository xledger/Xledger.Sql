using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableReplicateDistributionPolicy : TableDistributionPolicy, IEquatable<TableReplicateDistributionPolicy> {
        public TableReplicateDistributionPolicy() {

        }
    
        public ScriptDom.TableReplicateDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.TableReplicateDistributionPolicy();
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
            return Equals(obj as TableReplicateDistributionPolicy);
        } 
        
        public bool Equals(TableReplicateDistributionPolicy other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(TableReplicateDistributionPolicy left, TableReplicateDistributionPolicy right) {
            return EqualityComparer<TableReplicateDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableReplicateDistributionPolicy left, TableReplicateDistributionPolicy right) {
            return !(left == right);
        }
    
    }

}
