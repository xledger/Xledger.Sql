using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsStatement : TSqlStatement, IEquatable<ExecuteAsStatement> {
        bool withNoRevert = false;
        VariableReference cookie;
        ExecuteContext executeContext;
    
        public bool WithNoRevert => withNoRevert;
        public VariableReference Cookie => cookie;
        public ExecuteContext ExecuteContext => executeContext;
    
        public ExecuteAsStatement(bool withNoRevert = false, VariableReference cookie = null, ExecuteContext executeContext = null) {
            this.withNoRevert = withNoRevert;
            this.cookie = cookie;
            this.executeContext = executeContext;
        }
    
        public ScriptDom.ExecuteAsStatement ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsStatement();
            ret.WithNoRevert = withNoRevert;
            ret.Cookie = (ScriptDom.VariableReference)cookie.ToMutable();
            ret.ExecuteContext = (ScriptDom.ExecuteContext)executeContext.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withNoRevert.GetHashCode();
            if (!(cookie is null)) {
                h = h * 23 + cookie.GetHashCode();
            }
            if (!(executeContext is null)) {
                h = h * 23 + executeContext.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsStatement);
        } 
        
        public bool Equals(ExecuteAsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoRevert, withNoRevert)) {
                return false;
            }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Cookie, cookie)) {
                return false;
            }
            if (!EqualityComparer<ExecuteContext>.Default.Equals(other.ExecuteContext, executeContext)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsStatement left, ExecuteAsStatement right) {
            return EqualityComparer<ExecuteAsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsStatement left, ExecuteAsStatement right) {
            return !(left == right);
        }
    
    }

}
