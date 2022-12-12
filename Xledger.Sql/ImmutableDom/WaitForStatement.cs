using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WaitForStatement : TSqlStatement, IEquatable<WaitForStatement> {
        ScriptDom.WaitForOption waitForOption = ScriptDom.WaitForOption.Delay;
        ValueExpression parameter;
        ScalarExpression timeout;
        WaitForSupportedStatement statement;
    
        public ScriptDom.WaitForOption WaitForOption => waitForOption;
        public ValueExpression Parameter => parameter;
        public ScalarExpression Timeout => timeout;
        public WaitForSupportedStatement Statement => statement;
    
        public WaitForStatement(ScriptDom.WaitForOption waitForOption = ScriptDom.WaitForOption.Delay, ValueExpression parameter = null, ScalarExpression timeout = null, WaitForSupportedStatement statement = null) {
            this.waitForOption = waitForOption;
            this.parameter = parameter;
            this.timeout = timeout;
            this.statement = statement;
        }
    
        public ScriptDom.WaitForStatement ToMutableConcrete() {
            var ret = new ScriptDom.WaitForStatement();
            ret.WaitForOption = waitForOption;
            ret.Parameter = (ScriptDom.ValueExpression)parameter.ToMutable();
            ret.Timeout = (ScriptDom.ScalarExpression)timeout.ToMutable();
            ret.Statement = (ScriptDom.WaitForSupportedStatement)statement.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + waitForOption.GetHashCode();
            if (!(parameter is null)) {
                h = h * 23 + parameter.GetHashCode();
            }
            if (!(timeout is null)) {
                h = h * 23 + timeout.GetHashCode();
            }
            if (!(statement is null)) {
                h = h * 23 + statement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WaitForStatement);
        } 
        
        public bool Equals(WaitForStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.WaitForOption>.Default.Equals(other.WaitForOption, waitForOption)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Timeout, timeout)) {
                return false;
            }
            if (!EqualityComparer<WaitForSupportedStatement>.Default.Equals(other.Statement, statement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WaitForStatement left, WaitForStatement right) {
            return EqualityComparer<WaitForStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WaitForStatement left, WaitForStatement right) {
            return !(left == right);
        }
    
    }

}