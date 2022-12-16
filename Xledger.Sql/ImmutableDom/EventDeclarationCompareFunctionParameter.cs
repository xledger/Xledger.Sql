using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventDeclarationCompareFunctionParameter : BooleanExpression, IEquatable<EventDeclarationCompareFunctionParameter> {
        protected EventSessionObjectName name;
        protected SourceDeclaration sourceDeclaration;
        protected ScalarExpression eventValue;
    
        public EventSessionObjectName Name => name;
        public SourceDeclaration SourceDeclaration => sourceDeclaration;
        public ScalarExpression EventValue => eventValue;
    
        public EventDeclarationCompareFunctionParameter(EventSessionObjectName name = null, SourceDeclaration sourceDeclaration = null, ScalarExpression eventValue = null) {
            this.name = name;
            this.sourceDeclaration = sourceDeclaration;
            this.eventValue = eventValue;
        }
    
        public ScriptDom.EventDeclarationCompareFunctionParameter ToMutableConcrete() {
            var ret = new ScriptDom.EventDeclarationCompareFunctionParameter();
            ret.Name = (ScriptDom.EventSessionObjectName)name?.ToMutable();
            ret.SourceDeclaration = (ScriptDom.SourceDeclaration)sourceDeclaration?.ToMutable();
            ret.EventValue = (ScriptDom.ScalarExpression)eventValue?.ToMutable();
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
            if (!(sourceDeclaration is null)) {
                h = h * 23 + sourceDeclaration.GetHashCode();
            }
            if (!(eventValue is null)) {
                h = h * 23 + eventValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventDeclarationCompareFunctionParameter);
        } 
        
        public bool Equals(EventDeclarationCompareFunctionParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<EventSessionObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SourceDeclaration>.Default.Equals(other.SourceDeclaration, sourceDeclaration)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.EventValue, eventValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) {
            return EqualityComparer<EventDeclarationCompareFunctionParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EventDeclarationCompareFunctionParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceDeclaration, othr.sourceDeclaration);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.eventValue, othr.eventValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EventDeclarationCompareFunctionParameter left, EventDeclarationCompareFunctionParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
