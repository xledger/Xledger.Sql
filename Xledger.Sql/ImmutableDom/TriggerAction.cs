using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            ret.EventTypeGroup = (ScriptDom.EventTypeGroupContainer)eventTypeGroup?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TriggerAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.triggerActionType, othr.triggerActionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventTypeGroup, othr.eventTypeGroup);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TriggerAction left, TriggerAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TriggerAction left, TriggerAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TriggerAction left, TriggerAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TriggerAction left, TriggerAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TriggerAction FromMutable(ScriptDom.TriggerAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TriggerAction)) { throw new NotImplementedException("Unexpected subtype of TriggerAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TriggerAction(
                triggerActionType: fragment.TriggerActionType,
                eventTypeGroup: ImmutableDom.EventTypeGroupContainer.FromMutable(fragment.EventTypeGroup)
            );
        }
    
    }

}
