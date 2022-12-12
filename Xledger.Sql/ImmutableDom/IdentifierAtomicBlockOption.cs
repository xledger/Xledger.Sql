using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierAtomicBlockOption : AtomicBlockOption, IEquatable<IdentifierAtomicBlockOption> {
        Identifier @value;
    
        public Identifier Value => @value;
    
        public IdentifierAtomicBlockOption(Identifier @value = null, ScriptDom.AtomicBlockOptionKind optionKind = ScriptDom.AtomicBlockOptionKind.IsolationLevel) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IdentifierAtomicBlockOption ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierAtomicBlockOption();
            ret.Value = (ScriptDom.Identifier)@value.ToMutable();
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
            return Equals(obj as IdentifierAtomicBlockOption);
        } 
        
        public bool Equals(IdentifierAtomicBlockOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AtomicBlockOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierAtomicBlockOption left, IdentifierAtomicBlockOption right) {
            return EqualityComparer<IdentifierAtomicBlockOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierAtomicBlockOption left, IdentifierAtomicBlockOption right) {
            return !(left == right);
        }
    
    }

}