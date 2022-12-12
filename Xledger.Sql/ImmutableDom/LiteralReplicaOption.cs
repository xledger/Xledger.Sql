using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralReplicaOption : AvailabilityReplicaOption, IEquatable<LiteralReplicaOption> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralReplicaOption(Literal @value = null, ScriptDom.AvailabilityReplicaOptionKind optionKind = ScriptDom.AvailabilityReplicaOptionKind.AvailabilityMode) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralReplicaOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralReplicaOption();
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
            return Equals(obj as LiteralReplicaOption);
        } 
        
        public bool Equals(LiteralReplicaOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AvailabilityReplicaOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralReplicaOption left, LiteralReplicaOption right) {
            return EqualityComparer<LiteralReplicaOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralReplicaOption left, LiteralReplicaOption right) {
            return !(left == right);
        }
    
    }

}
