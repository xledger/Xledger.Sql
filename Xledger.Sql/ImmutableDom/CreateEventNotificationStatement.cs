using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateEventNotificationStatement : TSqlStatement, IEquatable<CreateEventNotificationStatement> {
        protected Identifier name;
        protected EventNotificationObjectScope scope;
        protected bool withFanIn = false;
        protected IReadOnlyList<EventTypeGroupContainer> eventTypeGroups;
        protected Literal brokerService;
        protected Literal brokerInstanceSpecifier;
    
        public Identifier Name => name;
        public EventNotificationObjectScope Scope => scope;
        public bool WithFanIn => withFanIn;
        public IReadOnlyList<EventTypeGroupContainer> EventTypeGroups => eventTypeGroups;
        public Literal BrokerService => brokerService;
        public Literal BrokerInstanceSpecifier => brokerInstanceSpecifier;
    
        public CreateEventNotificationStatement(Identifier name = null, EventNotificationObjectScope scope = null, bool withFanIn = false, IReadOnlyList<EventTypeGroupContainer> eventTypeGroups = null, Literal brokerService = null, Literal brokerInstanceSpecifier = null) {
            this.name = name;
            this.scope = scope;
            this.withFanIn = withFanIn;
            this.eventTypeGroups = ImmList<EventTypeGroupContainer>.FromList(eventTypeGroups);
            this.brokerService = brokerService;
            this.brokerInstanceSpecifier = brokerInstanceSpecifier;
        }
    
        public ScriptDom.CreateEventNotificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateEventNotificationStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Scope = (ScriptDom.EventNotificationObjectScope)scope?.ToMutable();
            ret.WithFanIn = withFanIn;
            ret.EventTypeGroups.AddRange(eventTypeGroups.SelectList(c => (ScriptDom.EventTypeGroupContainer)c?.ToMutable()));
            ret.BrokerService = (ScriptDom.Literal)brokerService?.ToMutable();
            ret.BrokerInstanceSpecifier = (ScriptDom.Literal)brokerInstanceSpecifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(scope is null)) {
                h = h * 23 + scope.GetHashCode();
            }
            h = h * 23 + withFanIn.GetHashCode();
            h = h * 23 + eventTypeGroups.GetHashCode();
            if (!(brokerService is null)) {
                h = h * 23 + brokerService.GetHashCode();
            }
            if (!(brokerInstanceSpecifier is null)) {
                h = h * 23 + brokerInstanceSpecifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateEventNotificationStatement);
        } 
        
        public bool Equals(CreateEventNotificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<EventNotificationObjectScope>.Default.Equals(other.Scope, scope)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithFanIn, withFanIn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventTypeGroupContainer>>.Default.Equals(other.EventTypeGroups, eventTypeGroups)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.BrokerService, brokerService)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.BrokerInstanceSpecifier, brokerInstanceSpecifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateEventNotificationStatement left, CreateEventNotificationStatement right) {
            return EqualityComparer<CreateEventNotificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateEventNotificationStatement left, CreateEventNotificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateEventNotificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.scope, othr.scope);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withFanIn, othr.withFanIn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventTypeGroups, othr.eventTypeGroups);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.brokerService, othr.brokerService);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.brokerInstanceSpecifier, othr.brokerInstanceSpecifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateEventNotificationStatement left, CreateEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateEventNotificationStatement left, CreateEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateEventNotificationStatement left, CreateEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateEventNotificationStatement left, CreateEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
