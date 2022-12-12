using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GenericConfigurationOption : DatabaseConfigurationSetOption, IEquatable<GenericConfigurationOption> {
        IdentifierOrScalarExpression genericOptionState;
    
        public IdentifierOrScalarExpression GenericOptionState => genericOptionState;
    
        public GenericConfigurationOption(IdentifierOrScalarExpression genericOptionState = null, ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.genericOptionState = genericOptionState;
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public ScriptDom.GenericConfigurationOption ToMutableConcrete() {
            var ret = new ScriptDom.GenericConfigurationOption();
            ret.GenericOptionState = (ScriptDom.IdentifierOrScalarExpression)genericOptionState.ToMutable();
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(genericOptionState is null)) {
                h = h * 23 + genericOptionState.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GenericConfigurationOption);
        } 
        
        public bool Equals(GenericConfigurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrScalarExpression>.Default.Equals(other.GenericOptionState, genericOptionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseConfigSetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GenericOptionKind, genericOptionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GenericConfigurationOption left, GenericConfigurationOption right) {
            return EqualityComparer<GenericConfigurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GenericConfigurationOption left, GenericConfigurationOption right) {
            return !(left == right);
        }
    
    }

}
