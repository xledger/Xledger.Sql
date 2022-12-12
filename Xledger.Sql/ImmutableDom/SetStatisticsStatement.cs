using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetStatisticsStatement : SetOnOffStatement, IEquatable<SetStatisticsStatement> {
        ScriptDom.SetStatisticsOptions options = ScriptDom.SetStatisticsOptions.None;
    
        public ScriptDom.SetStatisticsOptions Options => options;
    
        public SetStatisticsStatement(ScriptDom.SetStatisticsOptions options = ScriptDom.SetStatisticsOptions.None, bool isOn = false) {
            this.options = options;
            this.isOn = isOn;
        }
    
        public ScriptDom.SetStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetStatisticsStatement();
            ret.Options = options;
            ret.IsOn = isOn;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + isOn.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetStatisticsStatement);
        } 
        
        public bool Equals(SetStatisticsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SetStatisticsOptions>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetStatisticsStatement left, SetStatisticsStatement right) {
            return EqualityComparer<SetStatisticsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetStatisticsStatement left, SetStatisticsStatement right) {
            return !(left == right);
        }
    
    }

}
