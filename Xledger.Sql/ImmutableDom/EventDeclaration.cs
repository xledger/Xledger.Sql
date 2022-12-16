using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventDeclaration : TSqlFragment, IEquatable<EventDeclaration> {
        protected EventSessionObjectName objectName;
        protected IReadOnlyList<EventDeclarationSetParameter> eventDeclarationSetParameters;
        protected IReadOnlyList<EventSessionObjectName> eventDeclarationActionParameters;
        protected BooleanExpression eventDeclarationPredicateParameter;
    
        public EventSessionObjectName ObjectName => objectName;
        public IReadOnlyList<EventDeclarationSetParameter> EventDeclarationSetParameters => eventDeclarationSetParameters;
        public IReadOnlyList<EventSessionObjectName> EventDeclarationActionParameters => eventDeclarationActionParameters;
        public BooleanExpression EventDeclarationPredicateParameter => eventDeclarationPredicateParameter;
    
        public EventDeclaration(EventSessionObjectName objectName = null, IReadOnlyList<EventDeclarationSetParameter> eventDeclarationSetParameters = null, IReadOnlyList<EventSessionObjectName> eventDeclarationActionParameters = null, BooleanExpression eventDeclarationPredicateParameter = null) {
            this.objectName = objectName;
            this.eventDeclarationSetParameters = ImmList<EventDeclarationSetParameter>.FromList(eventDeclarationSetParameters);
            this.eventDeclarationActionParameters = ImmList<EventSessionObjectName>.FromList(eventDeclarationActionParameters);
            this.eventDeclarationPredicateParameter = eventDeclarationPredicateParameter;
        }
    
        public ScriptDom.EventDeclaration ToMutableConcrete() {
            var ret = new ScriptDom.EventDeclaration();
            ret.ObjectName = (ScriptDom.EventSessionObjectName)objectName?.ToMutable();
            ret.EventDeclarationSetParameters.AddRange(eventDeclarationSetParameters.SelectList(c => (ScriptDom.EventDeclarationSetParameter)c?.ToMutable()));
            ret.EventDeclarationActionParameters.AddRange(eventDeclarationActionParameters.SelectList(c => (ScriptDom.EventSessionObjectName)c?.ToMutable()));
            ret.EventDeclarationPredicateParameter = (ScriptDom.BooleanExpression)eventDeclarationPredicateParameter?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(objectName is null)) {
                h = h * 23 + objectName.GetHashCode();
            }
            h = h * 23 + eventDeclarationSetParameters.GetHashCode();
            h = h * 23 + eventDeclarationActionParameters.GetHashCode();
            if (!(eventDeclarationPredicateParameter is null)) {
                h = h * 23 + eventDeclarationPredicateParameter.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventDeclaration);
        } 
        
        public bool Equals(EventDeclaration other) {
            if (other is null) { return false; }
            if (!EqualityComparer<EventSessionObjectName>.Default.Equals(other.ObjectName, objectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventDeclarationSetParameter>>.Default.Equals(other.EventDeclarationSetParameters, eventDeclarationSetParameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventSessionObjectName>>.Default.Equals(other.EventDeclarationActionParameters, eventDeclarationActionParameters)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.EventDeclarationPredicateParameter, eventDeclarationPredicateParameter)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventDeclaration left, EventDeclaration right) {
            return EqualityComparer<EventDeclaration>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventDeclaration left, EventDeclaration right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EventDeclaration)that;
            compare = Comparer.DefaultInvariant.Compare(this.objectName, othr.objectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventDeclarationSetParameters, othr.eventDeclarationSetParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventDeclarationActionParameters, othr.eventDeclarationActionParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventDeclarationPredicateParameter, othr.eventDeclarationPredicateParameter);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EventDeclaration left, EventDeclaration right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EventDeclaration left, EventDeclaration right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EventDeclaration left, EventDeclaration right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EventDeclaration left, EventDeclaration right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
