using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GeneralSetCommand : SetCommand, IEquatable<GeneralSetCommand> {
        protected ScriptDom.GeneralSetCommandType commandType = ScriptDom.GeneralSetCommandType.None;
        protected ScalarExpression parameter;
    
        public ScriptDom.GeneralSetCommandType CommandType => commandType;
        public ScalarExpression Parameter => parameter;
    
        public GeneralSetCommand(ScriptDom.GeneralSetCommandType commandType = ScriptDom.GeneralSetCommandType.None, ScalarExpression parameter = null) {
            this.commandType = commandType;
            this.parameter = parameter;
        }
    
        public ScriptDom.GeneralSetCommand ToMutableConcrete() {
            var ret = new ScriptDom.GeneralSetCommand();
            ret.CommandType = commandType;
            ret.Parameter = (ScriptDom.ScalarExpression)parameter?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GeneralSetCommand)that;
            compare = Comparer.DefaultInvariant.Compare(this.commandType, othr.commandType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameter, othr.parameter);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (GeneralSetCommand left, GeneralSetCommand right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GeneralSetCommand left, GeneralSetCommand right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GeneralSetCommand left, GeneralSetCommand right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GeneralSetCommand left, GeneralSetCommand right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GeneralSetCommand FromMutable(ScriptDom.GeneralSetCommand fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GeneralSetCommand)) { throw new NotImplementedException("Unexpected subtype of GeneralSetCommand not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GeneralSetCommand(
                commandType: fragment.CommandType,
                parameter: ImmutableDom.ScalarExpression.FromMutable(fragment.Parameter)
            );
        }
    
    }

}
