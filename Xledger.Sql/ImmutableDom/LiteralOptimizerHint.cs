using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralOptimizerHint : OptimizerHint, IEquatable<LiteralOptimizerHint> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralOptimizerHint(Literal @value = null, ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified) {
            this.@value = @value;
            this.hintKind = hintKind;
        }
    
        public ScriptDom.LiteralOptimizerHint ToMutableConcrete() {
            var ret = new ScriptDom.LiteralOptimizerHint();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.HintKind = hintKind;
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
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralOptimizerHint);
        } 
        
        public bool Equals(LiteralOptimizerHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptimizerHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralOptimizerHint left, LiteralOptimizerHint right) {
            return EqualityComparer<LiteralOptimizerHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralOptimizerHint left, LiteralOptimizerHint right) {
            return !(left == right);
        }
    
    }

}
