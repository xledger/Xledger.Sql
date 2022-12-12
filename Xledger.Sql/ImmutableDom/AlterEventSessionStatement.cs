using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterEventSessionStatement : EventSessionStatement, IEquatable<AlterEventSessionStatement> {
        ScriptDom.AlterEventSessionStatementType statementType = ScriptDom.AlterEventSessionStatementType.Unknown;
        IReadOnlyList<EventSessionObjectName> dropEventDeclarations;
        IReadOnlyList<EventSessionObjectName> dropTargetDeclarations;
    
        public ScriptDom.AlterEventSessionStatementType StatementType => statementType;
        public IReadOnlyList<EventSessionObjectName> DropEventDeclarations => dropEventDeclarations;
        public IReadOnlyList<EventSessionObjectName> DropTargetDeclarations => dropTargetDeclarations;
    
        public AlterEventSessionStatement(ScriptDom.AlterEventSessionStatementType statementType = ScriptDom.AlterEventSessionStatementType.Unknown, IReadOnlyList<EventSessionObjectName> dropEventDeclarations = null, IReadOnlyList<EventSessionObjectName> dropTargetDeclarations = null, Identifier name = null, ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server, IReadOnlyList<EventDeclaration> eventDeclarations = null, IReadOnlyList<TargetDeclaration> targetDeclarations = null, IReadOnlyList<SessionOption> sessionOptions = null) {
            this.statementType = statementType;
            this.dropEventDeclarations = dropEventDeclarations is null ? ImmList<EventSessionObjectName>.Empty : ImmList<EventSessionObjectName>.FromList(dropEventDeclarations);
            this.dropTargetDeclarations = dropTargetDeclarations is null ? ImmList<EventSessionObjectName>.Empty : ImmList<EventSessionObjectName>.FromList(dropTargetDeclarations);
            this.name = name;
            this.sessionScope = sessionScope;
            this.eventDeclarations = eventDeclarations is null ? ImmList<EventDeclaration>.Empty : ImmList<EventDeclaration>.FromList(eventDeclarations);
            this.targetDeclarations = targetDeclarations is null ? ImmList<TargetDeclaration>.Empty : ImmList<TargetDeclaration>.FromList(targetDeclarations);
            this.sessionOptions = sessionOptions is null ? ImmList<SessionOption>.Empty : ImmList<SessionOption>.FromList(sessionOptions);
        }
    
        public ScriptDom.AlterEventSessionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterEventSessionStatement();
            ret.StatementType = statementType;
            ret.DropEventDeclarations.AddRange(dropEventDeclarations.Select(c => (ScriptDom.EventSessionObjectName)c.ToMutable()));
            ret.DropTargetDeclarations.AddRange(dropTargetDeclarations.Select(c => (ScriptDom.EventSessionObjectName)c.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.SessionScope = sessionScope;
            ret.EventDeclarations.AddRange(eventDeclarations.Select(c => (ScriptDom.EventDeclaration)c.ToMutable()));
            ret.TargetDeclarations.AddRange(targetDeclarations.Select(c => (ScriptDom.TargetDeclaration)c.ToMutable()));
            ret.SessionOptions.AddRange(sessionOptions.Select(c => (ScriptDom.SessionOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + statementType.GetHashCode();
            h = h * 23 + dropEventDeclarations.GetHashCode();
            h = h * 23 + dropTargetDeclarations.GetHashCode();
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
            return Equals(obj as AlterEventSessionStatement);
        } 
        
        public bool Equals(AlterEventSessionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterEventSessionStatementType>.Default.Equals(other.StatementType, statementType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventSessionObjectName>>.Default.Equals(other.DropEventDeclarations, dropEventDeclarations)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventSessionObjectName>>.Default.Equals(other.DropTargetDeclarations, dropTargetDeclarations)) {
                return false;
            }
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
        
        public static bool operator ==(AlterEventSessionStatement left, AlterEventSessionStatement right) {
            return EqualityComparer<AlterEventSessionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterEventSessionStatement left, AlterEventSessionStatement right) {
            return !(left == right);
        }
    
    }

}
