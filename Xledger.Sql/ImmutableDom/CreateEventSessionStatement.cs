using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateEventSessionStatement : EventSessionStatement, IEquatable<CreateEventSessionStatement> {
        public CreateEventSessionStatement(Identifier name = null, ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server, IReadOnlyList<EventDeclaration> eventDeclarations = null, IReadOnlyList<TargetDeclaration> targetDeclarations = null, IReadOnlyList<SessionOption> sessionOptions = null) {
            this.name = name;
            this.sessionScope = sessionScope;
            this.eventDeclarations = eventDeclarations is null ? ImmList<EventDeclaration>.Empty : ImmList<EventDeclaration>.FromList(eventDeclarations);
            this.targetDeclarations = targetDeclarations is null ? ImmList<TargetDeclaration>.Empty : ImmList<TargetDeclaration>.FromList(targetDeclarations);
            this.sessionOptions = sessionOptions is null ? ImmList<SessionOption>.Empty : ImmList<SessionOption>.FromList(sessionOptions);
        }
    
        public ScriptDom.CreateEventSessionStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateEventSessionStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.SessionScope = sessionScope;
            ret.EventDeclarations.AddRange(eventDeclarations.SelectList(c => (ScriptDom.EventDeclaration)c.ToMutable()));
            ret.TargetDeclarations.AddRange(targetDeclarations.SelectList(c => (ScriptDom.TargetDeclaration)c.ToMutable()));
            ret.SessionOptions.AddRange(sessionOptions.SelectList(c => (ScriptDom.SessionOption)c.ToMutable()));
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
            return Equals(obj as CreateEventSessionStatement);
        } 
        
        public bool Equals(CreateEventSessionStatement other) {
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
        
        public static bool operator ==(CreateEventSessionStatement left, CreateEventSessionStatement right) {
            return EqualityComparer<CreateEventSessionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateEventSessionStatement left, CreateEventSessionStatement right) {
            return !(left == right);
        }
    
    }

}
