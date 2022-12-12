using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxDopConfigurationOption : DatabaseConfigurationSetOption, IEquatable<MaxDopConfigurationOption> {
        Literal @value;
        bool primary = false;
    
        public Literal Value => @value;
        public bool Primary => primary;
    
        public MaxDopConfigurationOption(Literal @value = null, bool primary = false, ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.@value = @value;
            this.primary = primary;
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public ScriptDom.MaxDopConfigurationOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxDopConfigurationOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.Primary = primary;
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind.ToMutable();
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
            h = h * 23 + primary.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxDopConfigurationOption);
        } 
        
        public bool Equals(MaxDopConfigurationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Primary, primary)) {
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
        
        public static bool operator ==(MaxDopConfigurationOption left, MaxDopConfigurationOption right) {
            return EqualityComparer<MaxDopConfigurationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxDopConfigurationOption left, MaxDopConfigurationOption right) {
            return !(left == right);
        }
    
    }

}
