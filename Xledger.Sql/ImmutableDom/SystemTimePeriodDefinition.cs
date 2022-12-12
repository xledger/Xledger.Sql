using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SystemTimePeriodDefinition : TSqlFragment, IEquatable<SystemTimePeriodDefinition> {
        Identifier startTimeColumn;
        Identifier endTimeColumn;
    
        public Identifier StartTimeColumn => startTimeColumn;
        public Identifier EndTimeColumn => endTimeColumn;
    
        public SystemTimePeriodDefinition(Identifier startTimeColumn = null, Identifier endTimeColumn = null) {
            this.startTimeColumn = startTimeColumn;
            this.endTimeColumn = endTimeColumn;
        }
    
        public ScriptDom.SystemTimePeriodDefinition ToMutableConcrete() {
            var ret = new ScriptDom.SystemTimePeriodDefinition();
            ret.StartTimeColumn = (ScriptDom.Identifier)startTimeColumn.ToMutable();
            ret.EndTimeColumn = (ScriptDom.Identifier)endTimeColumn.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(startTimeColumn is null)) {
                h = h * 23 + startTimeColumn.GetHashCode();
            }
            if (!(endTimeColumn is null)) {
                h = h * 23 + endTimeColumn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SystemTimePeriodDefinition);
        } 
        
        public bool Equals(SystemTimePeriodDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.StartTimeColumn, startTimeColumn)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.EndTimeColumn, endTimeColumn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) {
            return EqualityComparer<SystemTimePeriodDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) {
            return !(left == right);
        }
    
    }

}
