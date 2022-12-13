using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DelayedDurabilityDatabaseOption : DatabaseOption, IEquatable<DelayedDurabilityDatabaseOption> {
        protected ScriptDom.DelayedDurabilityOptionKind @value = ScriptDom.DelayedDurabilityOptionKind.Disabled;
    
        public ScriptDom.DelayedDurabilityOptionKind Value => @value;
    
        public DelayedDurabilityDatabaseOption(ScriptDom.DelayedDurabilityOptionKind @value = ScriptDom.DelayedDurabilityOptionKind.Disabled, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DelayedDurabilityDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.DelayedDurabilityDatabaseOption();
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
            return Equals(obj as DelayedDurabilityDatabaseOption);
        } 
        
        public bool Equals(DelayedDurabilityDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DelayedDurabilityOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) {
            return EqualityComparer<DelayedDurabilityDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DelayedDurabilityDatabaseOption left, DelayedDurabilityDatabaseOption right) {
            return !(left == right);
        }
    
        public static DelayedDurabilityDatabaseOption FromMutable(ScriptDom.DelayedDurabilityDatabaseOption fragment) {
            return (DelayedDurabilityDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
