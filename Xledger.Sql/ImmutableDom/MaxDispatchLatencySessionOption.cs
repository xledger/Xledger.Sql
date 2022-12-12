using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxDispatchLatencySessionOption : SessionOption, IEquatable<MaxDispatchLatencySessionOption> {
        bool isInfinite = false;
        Literal @value;
    
        public bool IsInfinite => isInfinite;
        public Literal Value => @value;
    
        public MaxDispatchLatencySessionOption(bool isInfinite = false, Literal @value = null, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.isInfinite = isInfinite;
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxDispatchLatencySessionOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxDispatchLatencySessionOption();
            ret.IsInfinite = isInfinite;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isInfinite.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxDispatchLatencySessionOption);
        } 
        
        public bool Equals(MaxDispatchLatencySessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsInfinite, isInfinite)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) {
            return EqualityComparer<MaxDispatchLatencySessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxDispatchLatencySessionOption left, MaxDispatchLatencySessionOption right) {
            return !(left == right);
        }
    
    }

}
