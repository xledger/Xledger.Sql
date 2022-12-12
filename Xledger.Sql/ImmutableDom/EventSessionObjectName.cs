using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventSessionObjectName : TSqlFragment, IEquatable<EventSessionObjectName> {
        MultiPartIdentifier multiPartIdentifier;
    
        public MultiPartIdentifier MultiPartIdentifier => multiPartIdentifier;
    
        public EventSessionObjectName(MultiPartIdentifier multiPartIdentifier = null) {
            this.multiPartIdentifier = multiPartIdentifier;
        }
    
        public ScriptDom.EventSessionObjectName ToMutableConcrete() {
            var ret = new ScriptDom.EventSessionObjectName();
            ret.MultiPartIdentifier = (ScriptDom.MultiPartIdentifier)multiPartIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(multiPartIdentifier is null)) {
                h = h * 23 + multiPartIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventSessionObjectName);
        } 
        
        public bool Equals(EventSessionObjectName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.MultiPartIdentifier, multiPartIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventSessionObjectName left, EventSessionObjectName right) {
            return EqualityComparer<EventSessionObjectName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventSessionObjectName left, EventSessionObjectName right) {
            return !(left == right);
        }
    
    }

}
