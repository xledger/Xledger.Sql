using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralPrincipalOption : PrincipalOption, IEquatable<LiteralPrincipalOption> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralPrincipalOption(Literal @value = null, ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralPrincipalOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralPrincipalOption();
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
            return Equals(obj as LiteralPrincipalOption);
        } 
        
        public bool Equals(LiteralPrincipalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PrincipalOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralPrincipalOption left, LiteralPrincipalOption right) {
            return EqualityComparer<LiteralPrincipalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralPrincipalOption left, LiteralPrincipalOption right) {
            return !(left == right);
        }
    
    }

}
