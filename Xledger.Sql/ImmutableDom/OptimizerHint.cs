using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OptimizerHint : TSqlFragment, IEquatable<OptimizerHint> {
        ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified;
    
        public ScriptDom.OptimizerHintKind HintKind => hintKind;
    
        public OptimizerHint(ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified) {
            this.hintKind = hintKind;
        }
    
        public ScriptDom.OptimizerHint ToMutableConcrete() {
            var ret = new ScriptDom.OptimizerHint();
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OptimizerHint);
        } 
        
        public bool Equals(OptimizerHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptimizerHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OptimizerHint left, OptimizerHint right) {
            return EqualityComparer<OptimizerHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OptimizerHint left, OptimizerHint right) {
            return !(left == right);
        }
    
    }

}