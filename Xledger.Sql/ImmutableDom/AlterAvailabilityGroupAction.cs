using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAvailabilityGroupAction : TSqlFragment, IEquatable<AlterAvailabilityGroupAction> {
        protected ScriptDom.AlterAvailabilityGroupActionType actionType = ScriptDom.AlterAvailabilityGroupActionType.Failover;
    
        public ScriptDom.AlterAvailabilityGroupActionType ActionType => actionType;
    
        public AlterAvailabilityGroupAction(ScriptDom.AlterAvailabilityGroupActionType actionType = ScriptDom.AlterAvailabilityGroupActionType.Failover) {
            this.actionType = actionType;
        }
    
        public ScriptDom.AlterAvailabilityGroupAction ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupAction();
            ret.ActionType = actionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + actionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAvailabilityGroupAction);
        } 
        
        public bool Equals(AlterAvailabilityGroupAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterAvailabilityGroupActionType>.Default.Equals(other.ActionType, actionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAvailabilityGroupAction left, AlterAvailabilityGroupAction right) {
            return EqualityComparer<AlterAvailabilityGroupAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAvailabilityGroupAction left, AlterAvailabilityGroupAction right) {
            return !(left == right);
        }
    
        public static AlterAvailabilityGroupAction FromMutable(ScriptDom.AlterAvailabilityGroupAction fragment) {
            return (AlterAvailabilityGroupAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
