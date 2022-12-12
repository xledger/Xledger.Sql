using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WsdlPayloadOption : PayloadOption, IEquatable<WsdlPayloadOption> {
        protected bool isNone = false;
        protected Literal @value;
    
        public bool IsNone => isNone;
        public Literal Value => @value;
    
        public WsdlPayloadOption(bool isNone = false, Literal @value = null, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isNone = isNone;
            this.@value = @value;
            this.kind = kind;
        }
    
        public ScriptDom.WsdlPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.WsdlPayloadOption();
            ret.IsNone = isNone;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isNone.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WsdlPayloadOption);
        } 
        
        public bool Equals(WsdlPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNone, isNone)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WsdlPayloadOption left, WsdlPayloadOption right) {
            return EqualityComparer<WsdlPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WsdlPayloadOption left, WsdlPayloadOption right) {
            return !(left == right);
        }
    
    }

}
