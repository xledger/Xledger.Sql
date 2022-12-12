using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JsonKeyValue : ScalarExpression, IEquatable<JsonKeyValue> {
        ScalarExpression jsonKeyName;
        ScalarExpression jsonValue;
    
        public ScalarExpression JsonKeyName => jsonKeyName;
        public ScalarExpression JsonValue => jsonValue;
    
        public JsonKeyValue(ScalarExpression jsonKeyName = null, ScalarExpression jsonValue = null) {
            this.jsonKeyName = jsonKeyName;
            this.jsonValue = jsonValue;
        }
    
        public ScriptDom.JsonKeyValue ToMutableConcrete() {
            var ret = new ScriptDom.JsonKeyValue();
            ret.JsonKeyName = (ScriptDom.ScalarExpression)jsonKeyName.ToMutable();
            ret.JsonValue = (ScriptDom.ScalarExpression)jsonValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(jsonKeyName is null)) {
                h = h * 23 + jsonKeyName.GetHashCode();
            }
            if (!(jsonValue is null)) {
                h = h * 23 + jsonValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JsonKeyValue);
        } 
        
        public bool Equals(JsonKeyValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.JsonKeyName, jsonKeyName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.JsonValue, jsonValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JsonKeyValue left, JsonKeyValue right) {
            return EqualityComparer<JsonKeyValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JsonKeyValue left, JsonKeyValue right) {
            return !(left == right);
        }
    
    }

}