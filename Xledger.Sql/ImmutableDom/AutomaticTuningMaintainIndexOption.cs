using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutomaticTuningMaintainIndexOption : AutomaticTuningOption, IEquatable<AutomaticTuningMaintainIndexOption> {
        public AutomaticTuningMaintainIndexOption(ScriptDom.AutomaticTuningOptionKind optionKind = ScriptDom.AutomaticTuningOptionKind.Force_Last_Good_Plan, ScriptDom.AutomaticTuningOptionState @value = ScriptDom.AutomaticTuningOptionState.Off) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.AutomaticTuningMaintainIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.AutomaticTuningMaintainIndexOption();
            ret.OptionKind = optionKind;
            ret.Value = @value;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + @value.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutomaticTuningMaintainIndexOption);
        } 
        
        public bool Equals(AutomaticTuningMaintainIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutomaticTuningMaintainIndexOption left, AutomaticTuningMaintainIndexOption right) {
            return EqualityComparer<AutomaticTuningMaintainIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutomaticTuningMaintainIndexOption left, AutomaticTuningMaintainIndexOption right) {
            return !(left == right);
        }
    
        public static AutomaticTuningMaintainIndexOption FromMutable(ScriptDom.AutomaticTuningMaintainIndexOption fragment) {
            return (AutomaticTuningMaintainIndexOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
