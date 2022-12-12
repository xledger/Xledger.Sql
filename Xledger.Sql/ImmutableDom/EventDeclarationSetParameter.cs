using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventDeclarationSetParameter : TSqlFragment, IEquatable<EventDeclarationSetParameter> {
        Identifier eventField;
        ScalarExpression eventValue;
    
        public Identifier EventField => eventField;
        public ScalarExpression EventValue => eventValue;
    
        public EventDeclarationSetParameter(Identifier eventField = null, ScalarExpression eventValue = null) {
            this.eventField = eventField;
            this.eventValue = eventValue;
        }
    
        public ScriptDom.EventDeclarationSetParameter ToMutableConcrete() {
            var ret = new ScriptDom.EventDeclarationSetParameter();
            ret.EventField = (ScriptDom.Identifier)eventField.ToMutable();
            ret.EventValue = (ScriptDom.ScalarExpression)eventValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(eventField is null)) {
                h = h * 23 + eventField.GetHashCode();
            }
            if (!(eventValue is null)) {
                h = h * 23 + eventValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventDeclarationSetParameter);
        } 
        
        public bool Equals(EventDeclarationSetParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.EventField, eventField)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.EventValue, eventValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventDeclarationSetParameter left, EventDeclarationSetParameter right) {
            return EqualityComparer<EventDeclarationSetParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventDeclarationSetParameter left, EventDeclarationSetParameter right) {
            return !(left == right);
        }
    
    }

}