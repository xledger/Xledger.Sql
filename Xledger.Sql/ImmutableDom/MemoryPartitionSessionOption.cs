using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MemoryPartitionSessionOption : SessionOption, IEquatable<MemoryPartitionSessionOption> {
        ScriptDom.EventSessionMemoryPartitionModeType @value = ScriptDom.EventSessionMemoryPartitionModeType.Unknown;
    
        public ScriptDom.EventSessionMemoryPartitionModeType Value => @value;
    
        public MemoryPartitionSessionOption(ScriptDom.EventSessionMemoryPartitionModeType @value = ScriptDom.EventSessionMemoryPartitionModeType.Unknown, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MemoryPartitionSessionOption ToMutableConcrete() {
            var ret = new ScriptDom.MemoryPartitionSessionOption();
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
            return Equals(obj as MemoryPartitionSessionOption);
        } 
        
        public bool Equals(MemoryPartitionSessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventSessionMemoryPartitionModeType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) {
            return EqualityComparer<MemoryPartitionSessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MemoryPartitionSessionOption left, MemoryPartitionSessionOption right) {
            return !(left == right);
        }
    
    }

}
