using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventGroupContainer : EventTypeGroupContainer, IEquatable<EventGroupContainer> {
        ScriptDom.EventNotificationEventGroup eventGroup = ScriptDom.EventNotificationEventGroup.Unknown;
    
        public ScriptDom.EventNotificationEventGroup EventGroup => eventGroup;
    
        public EventGroupContainer(ScriptDom.EventNotificationEventGroup eventGroup = ScriptDom.EventNotificationEventGroup.Unknown) {
            this.eventGroup = eventGroup;
        }
    
        public ScriptDom.EventGroupContainer ToMutableConcrete() {
            var ret = new ScriptDom.EventGroupContainer();
            ret.EventGroup = eventGroup;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + eventGroup.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventGroupContainer);
        } 
        
        public bool Equals(EventGroupContainer other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventNotificationEventGroup>.Default.Equals(other.EventGroup, eventGroup)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventGroupContainer left, EventGroupContainer right) {
            return EqualityComparer<EventGroupContainer>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventGroupContainer left, EventGroupContainer right) {
            return !(left == right);
        }
    
    }

}