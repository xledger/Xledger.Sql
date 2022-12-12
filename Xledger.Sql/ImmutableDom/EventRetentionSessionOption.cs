using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventRetentionSessionOption : SessionOption, IEquatable<EventRetentionSessionOption> {
        ScriptDom.EventSessionEventRetentionModeType @value = ScriptDom.EventSessionEventRetentionModeType.Unknown;
    
        public ScriptDom.EventSessionEventRetentionModeType Value => @value;
    
        public EventRetentionSessionOption(ScriptDom.EventSessionEventRetentionModeType @value = ScriptDom.EventSessionEventRetentionModeType.Unknown, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.EventRetentionSessionOption ToMutableConcrete() {
            var ret = new ScriptDom.EventRetentionSessionOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventRetentionSessionOption);
        } 
        
        public bool Equals(EventRetentionSessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventSessionEventRetentionModeType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventRetentionSessionOption left, EventRetentionSessionOption right) {
            return EqualityComparer<EventRetentionSessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventRetentionSessionOption left, EventRetentionSessionOption right) {
            return !(left == right);
        }
    
    }

}
