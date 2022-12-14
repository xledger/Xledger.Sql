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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableRoundRobinDistributionPolicy)that;
            return compare;
        } 
        public static bool operator < (TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableRoundRobinDistributionPolicy left, TableRoundRobinDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TableRoundRobinDistributionPolicy FromMutable(ScriptDom.TableRoundRobinDistributionPolicy fragment) {
            return (TableRoundRobinDistributionPolicy)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
