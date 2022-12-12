using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralPayloadOption : PayloadOption, IEquatable<LiteralPayloadOption> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralPayloadOption(Literal @value = null, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.@value = @value;
            this.kind = kind;
        }
    
        public ScriptDom.LiteralPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralPayloadOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.Kind = kind;
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
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralPayloadOption);
        } 
        
        public bool Equals(LiteralPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralPayloadOption left, LiteralPayloadOption right) {
            return EqualityComparer<LiteralPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralPayloadOption left, LiteralPayloadOption right) {
            return !(left == right);
        }
    
    }

}