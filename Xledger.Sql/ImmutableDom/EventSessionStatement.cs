using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventSessionStatement : TSqlStatement, IEquatable<EventSessionStatement> {
        protected Identifier name;
        protected ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server;
        protected IReadOnlyList<EventDeclaration> eventDeclarations;
        protected IReadOnlyList<TargetDeclaration> targetDeclarations;
        protected IReadOnlyList<SessionOption> sessionOptions;
    
        public Identifier Name => name;
        public ScriptDom.EventSessionScope SessionScope => sessionScope;
        public IReadOnlyList<EventDeclaration> EventDeclarations => eventDeclarations;
        public IReadOnlyList<TargetDeclaration> TargetDeclarations => targetDeclarations;
        public IReadOnlyList<SessionOption> SessionOptions => sessionOptions;
    
        public EventSessionStatement(Identifier name = null, ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server, IReadOnlyList<EventDeclaration> eventDeclarations = null, IReadOnlyList<TargetDeclaration> targetDeclarations = null, IReadOnlyList<SessionOption> sessionOptions = null) {
            this.name = name;
            this.sessionScope = sessionScope;
            this.eventDeclarations = eventDeclarations.ToImmArray<EventDeclaration>();
            this.targetDeclarations = targetDeclarations.ToImmArray<TargetDeclaration>();
            this.sessionOptions = sessionOptions.ToImmArray<SessionOption>();
        }
    
        public ScriptDom.EventSessionStatement ToMutableConcrete() {
            var ret = new ScriptDom.EventSessionStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.SessionScope = sessionScope;
            ret.EventDeclarations.AddRange(eventDeclarations.Select(c => (ScriptDom.EventDeclaration)c?.ToMutable()));
            ret.TargetDeclarations.AddRange(targetDeclarations.Select(c => (ScriptDom.TargetDeclaration)c?.ToMutable()));
            ret.SessionOptions.AddRange(sessionOptions.Select(c => (ScriptDom.SessionOption)c?.ToMutable()));
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
            h = h * 23 + sessionScope.GetHashCode();
            h = h * 23 + eventDeclarations.GetHashCode();
            h = h * 23 + targetDeclarations.GetHashCode();
            h = h * 23 + sessionOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventSessionStatement);
        } 
        
        public bool Equals(EventSessionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EventSessionScope>.Default.Equals(other.SessionScope, sessionScope)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventDeclaration>>.Default.Equals(other.EventDeclarations, eventDeclarations)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TargetDeclaration>>.Default.Equals(other.TargetDeclarations, targetDeclarations)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SessionOption>>.Default.Equals(other.SessionOptions, sessionOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventSessionStatement left, EventSessionStatement right) {
            return EqualityComparer<EventSessionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventSessionStatement left, EventSessionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EventSessionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sessionScope, othr.sessionScope);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventDeclarations, othr.eventDeclarations);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.targetDeclarations, othr.targetDeclarations);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sessionOptions, othr.sessionOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (EventSessionStatement left, EventSessionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EventSessionStatement left, EventSessionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EventSessionStatement left, EventSessionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EventSessionStatement left, EventSessionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static EventSessionStatement FromMutable(ScriptDom.EventSessionStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.EventSessionStatement)) { return TSqlFragment.FromMutable(fragment) as EventSessionStatement; }
            return new EventSessionStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.ToImmArray(ImmutableDom.EventDeclaration.FromMutable),
                targetDeclarations: fragment.TargetDeclarations.ToImmArray(ImmutableDom.TargetDeclaration.FromMutable),
                sessionOptions: fragment.SessionOptions.ToImmArray(ImmutableDom.SessionOption.FromMutable)
            );
        }
    
    }

}
