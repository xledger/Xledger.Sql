using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAvailabilityGroupFailoverOption : TSqlFragment, IEquatable<AlterAvailabilityGroupFailoverOption> {
        protected ScriptDom.FailoverActionOptionKind optionKind = ScriptDom.FailoverActionOptionKind.Target;
        protected Literal @value;
    
        public ScriptDom.FailoverActionOptionKind OptionKind => optionKind;
        public Literal Value => @value;
    
        public AlterAvailabilityGroupFailoverOption(ScriptDom.FailoverActionOptionKind optionKind = ScriptDom.FailoverActionOptionKind.Target, Literal @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.AlterAvailabilityGroupFailoverOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupFailoverOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAvailabilityGroupFailoverOption);
        } 
        
        public bool Equals(AlterAvailabilityGroupFailoverOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FailoverActionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAvailabilityGroupFailoverOption left, AlterAvailabilityGroupFailoverOption right) {
            return EqualityComparer<AlterAvailabilityGroupFailoverOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAvailabilityGroupFailoverOption left, AlterAvailabilityGroupFailoverOption right) {
            return !(left == right);
        }
    
    }

}
