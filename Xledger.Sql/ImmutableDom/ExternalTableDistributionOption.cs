using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableDistributionOption : ExternalTableOption, IEquatable<ExternalTableDistributionOption> {
        protected ExternalTableDistributionPolicy @value;
    
        public ExternalTableDistributionPolicy Value => @value;
    
        public ExternalTableDistributionOption(ExternalTableDistributionPolicy @value = null, ScriptDom.ExternalTableOptionKind optionKind = ScriptDom.ExternalTableOptionKind.Distribution) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalTableDistributionOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableDistributionOption();
            ret.Value = (ScriptDom.ExternalTableDistributionPolicy)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalTableDistributionOption);
        } 
        
        public bool Equals(ExternalTableDistributionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExternalTableDistributionPolicy>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalTableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableDistributionOption left, ExternalTableDistributionOption right) {
            return EqualityComparer<ExternalTableDistributionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableDistributionOption left, ExternalTableDistributionOption right) {
            return !(left == right);
        }
    
    }

}
