using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateEventNotificationStatement : TSqlStatement, IEquatable<CreateEventNotificationStatement> {
        Identifier name;
        EventNotificationObjectScope scope;
        bool withFanIn = false;
        IReadOnlyList<EventTypeGroupContainer> eventTypeGroups;
        Literal brokerService;
        Literal brokerInstanceSpecifier;
    
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
            this.eventTypeGroups = eventTypeGroups is null ? ImmList<EventTypeGroupContainer>.Empty : ImmList<EventTypeGroupContainer>.FromList(eventTypeGroups);
            this.brokerService = brokerService;
            this.brokerInstanceSpecifier = brokerInstanceSpecifier;
        }
    
        public ScriptDom.CreateEventNotificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateEventNotificationStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Scope = (ScriptDom.EventNotificationObjectScope)scope.ToMutable();
            ret.WithFanIn = withFanIn;
            ret.EventTypeGroups.AddRange(eventTypeGroups.Select(c => (ScriptDom.EventTypeGroupContainer)c.ToMutable()));
            ret.BrokerService = (ScriptDom.Literal)brokerService.ToMutable();
            ret.BrokerInstanceSpecifier = (ScriptDom.Literal)brokerInstanceSpecifier.ToMutable();
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
    
    }

}