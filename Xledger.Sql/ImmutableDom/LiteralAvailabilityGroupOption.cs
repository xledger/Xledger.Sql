using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralAvailabilityGroupOption : AvailabilityGroupOption, IEquatable<LiteralAvailabilityGroupOption> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralAvailabilityGroupOption(Literal @value = null, ScriptDom.AvailabilityGroupOptionKind optionKind = ScriptDom.AvailabilityGroupOptionKind.RequiredCopiesToCommit) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralAvailabilityGroupOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralAvailabilityGroupOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
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
            return Equals(obj as LiteralAvailabilityGroupOption);
        } 
        
        public bool Equals(LiteralAvailabilityGroupOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityGroupOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralAvailabilityGroupOption left, LiteralAvailabilityGroupOption right) {
            return EqualityComparer<LiteralAvailabilityGroupOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralAvailabilityGroupOption left, LiteralAvailabilityGroupOption right) {
            return !(left == right);
        }
    
    }

}