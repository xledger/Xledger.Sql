using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SequenceOption : TSqlFragment, IEquatable<SequenceOption> {
        ScriptDom.SequenceOptionKind optionKind = ScriptDom.SequenceOptionKind.As;
        bool noValue = false;
    
        public ScriptDom.SequenceOptionKind OptionKind => optionKind;
        public bool NoValue => noValue;
    
        public SequenceOption(ScriptDom.SequenceOptionKind optionKind = ScriptDom.SequenceOptionKind.As, bool noValue = false) {
            this.optionKind = optionKind;
            this.noValue = noValue;
        }
    
        public ScriptDom.SequenceOption ToMutableConcrete() {
            var ret = new ScriptDom.SequenceOption();
            ret.OptionKind = optionKind;
            ret.NoValue = noValue;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + noValue.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SequenceOption);
        } 
        
        public bool Equals(SequenceOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SequenceOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NoValue, noValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SequenceOption left, SequenceOption right) {
            return EqualityComparer<SequenceOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SequenceOption left, SequenceOption right) {
            return !(left == right);
        }
    
    }

}
