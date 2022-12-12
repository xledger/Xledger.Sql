using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAvailabilityGroupFailoverAction : AlterAvailabilityGroupAction, IEquatable<AlterAvailabilityGroupFailoverAction> {
        protected IReadOnlyList<AlterAvailabilityGroupFailoverOption> options;
    
        public IReadOnlyList<AlterAvailabilityGroupFailoverOption> Options => options;
    
        public AlterAvailabilityGroupFailoverAction(IReadOnlyList<AlterAvailabilityGroupFailoverOption> options = null, ScriptDom.AlterAvailabilityGroupActionType actionType = ScriptDom.AlterAvailabilityGroupActionType.Failover) {
            this.options = options is null ? ImmList<AlterAvailabilityGroupFailoverOption>.Empty : ImmList<AlterAvailabilityGroupFailoverOption>.FromList(options);
            this.actionType = actionType;
        }
    
        public ScriptDom.AlterAvailabilityGroupFailoverAction ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupFailoverAction();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterAvailabilityGroupFailoverOption)c.ToMutable()));
            ret.ActionType = actionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + actionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAvailabilityGroupFailoverAction);
        } 
        
        public bool Equals(AlterAvailabilityGroupFailoverAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterAvailabilityGroupFailoverOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterAvailabilityGroupActionType>.Default.Equals(other.ActionType, actionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) {
            return EqualityComparer<AlterAvailabilityGroupFailoverAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) {
            return !(left == right);
        }
    
    }

}
