using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewHashDistributionPolicy : ViewDistributionPolicy, IEquatable<ViewHashDistributionPolicy> {
        Identifier distributionColumn;
    
        public Identifier DistributionColumn => distributionColumn;
    
        public ViewHashDistributionPolicy(Identifier distributionColumn = null) {
            this.distributionColumn = distributionColumn;
        }
    
        public ScriptDom.ViewHashDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.ViewHashDistributionPolicy();
            ret.DistributionColumn = (ScriptDom.Identifier)distributionColumn.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(distributionColumn is null)) {
                h = h * 23 + distributionColumn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ViewHashDistributionPolicy);
        } 
        
        public bool Equals(ViewHashDistributionPolicy other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionColumn, distributionColumn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ViewHashDistributionPolicy left, ViewHashDistributionPolicy right) {
            return EqualityComparer<ViewHashDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewHashDistributionPolicy left, ViewHashDistributionPolicy right) {
            return !(left == right);
        }
    
    }

}
