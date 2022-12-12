using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralAtomicBlockOption : AtomicBlockOption, IEquatable<LiteralAtomicBlockOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralAtomicBlockOption(Literal @value = null, ScriptDom.AtomicBlockOptionKind optionKind = ScriptDom.AtomicBlockOptionKind.IsolationLevel) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralAtomicBlockOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralAtomicBlockOption();
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
            return Equals(obj as LiteralAtomicBlockOption);
        } 
        
        public bool Equals(LiteralAtomicBlockOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AtomicBlockOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralAtomicBlockOption left, LiteralAtomicBlockOption right) {
            return EqualityComparer<LiteralAtomicBlockOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralAtomicBlockOption left, LiteralAtomicBlockOption right) {
            return !(left == right);
        }
    
    }

}
