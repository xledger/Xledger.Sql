using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GeneralSetCommand : SetCommand, IEquatable<GeneralSetCommand> {
        ScriptDom.GeneralSetCommandType commandType = ScriptDom.GeneralSetCommandType.None;
        ScalarExpression parameter;
    
        public ScriptDom.GeneralSetCommandType CommandType => commandType;
        public ScalarExpression Parameter => parameter;
    
        public GeneralSetCommand(ScriptDom.GeneralSetCommandType commandType = ScriptDom.GeneralSetCommandType.None, ScalarExpression parameter = null) {
            this.commandType = commandType;
            this.parameter = parameter;
        }
    
        public ScriptDom.GeneralSetCommand ToMutableConcrete() {
            var ret = new ScriptDom.GeneralSetCommand();
            ret.CommandType = commandType;
            ret.Parameter = (ScriptDom.ScalarExpression)parameter.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + commandType.GetHashCode();
            if (!(parameter is null)) {
                h = h * 23 + parameter.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GeneralSetCommand);
        } 
        
        public bool Equals(GeneralSetCommand other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.GeneralSetCommandType>.Default.Equals(other.CommandType, commandType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GeneralSetCommand left, GeneralSetCommand right) {
            return EqualityComparer<GeneralSetCommand>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GeneralSetCommand left, GeneralSetCommand right) {
            return !(left == right);
        }
    
    }

}
