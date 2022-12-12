using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffOptionValue : OptionValue, IEquatable<OnOffOptionValue> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffOptionValue(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet) {
            this.optionState = optionState;
        }
    
        public ScriptDom.OnOffOptionValue ToMutableConcrete() {
            var ret = new ScriptDom.OnOffOptionValue();
            ret.OptionState = optionState;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnOffOptionValue);
        } 
        
        public bool Equals(OnOffOptionValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffOptionValue left, OnOffOptionValue right) {
            return EqualityComparer<OnOffOptionValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffOptionValue left, OnOffOptionValue right) {
            return !(left == right);
        }
    
    }

}
