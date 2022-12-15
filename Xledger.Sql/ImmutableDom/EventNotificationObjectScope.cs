using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventNotificationObjectScope : TSqlFragment, IEquatable<EventNotificationObjectScope> {
        protected ScriptDom.EventNotificationTarget target = ScriptDom.EventNotificationTarget.Unknown;
        protected SchemaObjectName queueName;
    
        public ScriptDom.EventNotificationTarget Target => target;
        public SchemaObjectName QueueName => queueName;
    
        public EventNotificationObjectScope(ScriptDom.EventNotificationTarget target = ScriptDom.EventNotificationTarget.Unknown, SchemaObjectName queueName = null) {
            this.target = target;
            this.queueName = queueName;
        }
    
        public ScriptDom.EventNotificationObjectScope ToMutableConcrete() {
            var ret = new ScriptDom.EventNotificationObjectScope();
            ret.Target = target;
            ret.QueueName = (ScriptDom.SchemaObjectName)queueName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + target.GetHashCode();
            if (!(queueName is null)) {
                h = h * 23 + queueName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventNotificationObjectScope);
        } 
        
        public bool Equals(EventNotificationObjectScope other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventNotificationTarget>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.QueueName, queueName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventNotificationObjectScope left, EventNotificationObjectScope right) {
            return EqualityComparer<EventNotificationObjectScope>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventNotificationObjectScope left, EventNotificationObjectScope right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EventNotificationObjectScope)that;
            compare = Comparer.DefaultInvariant.Compare(this.target, othr.target);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queueName, othr.queueName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EventNotificationObjectScope left, EventNotificationObjectScope right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EventNotificationObjectScope left, EventNotificationObjectScope right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EventNotificationObjectScope left, EventNotificationObjectScope right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EventNotificationObjectScope left, EventNotificationObjectScope right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
