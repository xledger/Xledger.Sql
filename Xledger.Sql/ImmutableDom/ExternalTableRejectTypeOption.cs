using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableRejectTypeOption : ExternalTableOption, IEquatable<ExternalTableRejectTypeOption> {
        ScriptDom.ExternalTableRejectType @value = ScriptDom.ExternalTableRejectType.Value;
    
        public ScriptDom.ExternalTableRejectType Value => @value;
    
        public ExternalTableRejectTypeOption(ScriptDom.ExternalTableRejectType @value = ScriptDom.ExternalTableRejectType.Value, ScriptDom.ExternalTableOptionKind optionKind = ScriptDom.ExternalTableOptionKind.Distribution) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalTableRejectTypeOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableRejectTypeOption();
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
            return Equals(obj as ExternalTableRejectTypeOption);
        } 
        
        public bool Equals(ExternalTableRejectTypeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExternalTableRejectType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalTableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableRejectTypeOption left, ExternalTableRejectTypeOption right) {
            return EqualityComparer<ExternalTableRejectTypeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableRejectTypeOption left, ExternalTableRejectTypeOption right) {
            return !(left == right);
        }
    
    }

}