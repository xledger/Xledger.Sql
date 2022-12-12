using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TriggerObject : TSqlFragment, IEquatable<TriggerObject> {
        SchemaObjectName name;
        ScriptDom.TriggerScope triggerScope = ScriptDom.TriggerScope.Normal;
    
        public SchemaObjectName Name => name;
        public ScriptDom.TriggerScope TriggerScope => triggerScope;
    
        public TriggerObject(SchemaObjectName name = null, ScriptDom.TriggerScope triggerScope = ScriptDom.TriggerScope.Normal) {
            this.name = name;
            this.triggerScope = triggerScope;
        }
    
        public ScriptDom.TriggerObject ToMutableConcrete() {
            var ret = new ScriptDom.TriggerObject();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.TriggerScope = triggerScope;
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
            h = h * 23 + triggerScope.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TriggerObject);
        } 
        
        public bool Equals(TriggerObject other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TriggerScope>.Default.Equals(other.TriggerScope, triggerScope)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TriggerObject left, TriggerObject right) {
            return EqualityComparer<TriggerObject>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TriggerObject left, TriggerObject right) {
            return !(left == right);
        }
    
    }

}
