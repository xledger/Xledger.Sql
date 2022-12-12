using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TriggerAction : TSqlFragment, IEquatable<TriggerAction> {
        protected ScriptDom.TriggerActionType triggerActionType = ScriptDom.TriggerActionType.Delete;
        protected EventTypeGroupContainer eventTypeGroup;
    
        public ScriptDom.TriggerActionType TriggerActionType => triggerActionType;
        public EventTypeGroupContainer EventTypeGroup => eventTypeGroup;
    
        public TriggerAction(ScriptDom.TriggerActionType triggerActionType = ScriptDom.TriggerActionType.Delete, EventTypeGroupContainer eventTypeGroup = null) {
            this.triggerActionType = triggerActionType;
            this.eventTypeGroup = eventTypeGroup;
        }
    
        public ScriptDom.TriggerAction ToMutableConcrete() {
            var ret = new ScriptDom.TriggerAction();
            ret.TriggerActionType = triggerActionType;
            ret.EventTypeGroup = (ScriptDom.EventTypeGroupContainer)eventTypeGroup.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + triggerActionType.GetHashCode();
            if (!(eventTypeGroup is null)) {
                h = h * 23 + eventTypeGroup.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TriggerAction);
        } 
        
        public bool Equals(TriggerAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TriggerActionType>.Default.Equals(other.TriggerActionType, triggerActionType)) {
                return false;
            }
            if (!EqualityComparer<EventTypeGroupContainer>.Default.Equals(other.EventTypeGroup, eventTypeGroup)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TriggerAction left, TriggerAction right) {
            return EqualityComparer<TriggerAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TriggerAction left, TriggerAction right) {
            return !(left == right);
        }
    
    }

}
