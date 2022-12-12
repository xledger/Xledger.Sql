using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteContext : TSqlFragment, IEquatable<ExecuteContext> {
        ScalarExpression principal;
        ScriptDom.ExecuteAsOption kind = ScriptDom.ExecuteAsOption.Caller;
    
        public ScalarExpression Principal => principal;
        public ScriptDom.ExecuteAsOption Kind => kind;
    
        public ExecuteContext(ScalarExpression principal = null, ScriptDom.ExecuteAsOption kind = ScriptDom.ExecuteAsOption.Caller) {
            this.principal = principal;
            this.kind = kind;
        }
    
        public ScriptDom.ExecuteContext ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteContext();
            ret.Principal = (ScriptDom.ScalarExpression)principal.ToMutable();
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(principal is null)) {
                h = h * 23 + principal.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteContext);
        } 
        
        public bool Equals(ExecuteContext other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Principal, principal)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExecuteAsOption>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteContext left, ExecuteContext right) {
            return EqualityComparer<ExecuteContext>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteContext left, ExecuteContext right) {
            return !(left == right);
        }
    
    }

}
