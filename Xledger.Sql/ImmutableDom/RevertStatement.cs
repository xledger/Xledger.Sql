using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RevertStatement : TSqlStatement, IEquatable<RevertStatement> {
        ScalarExpression cookie;
    
        public ScalarExpression Cookie => cookie;
    
        public RevertStatement(ScalarExpression cookie = null) {
            this.cookie = cookie;
        }
    
        public ScriptDom.RevertStatement ToMutableConcrete() {
            var ret = new ScriptDom.RevertStatement();
            ret.Cookie = (ScriptDom.ScalarExpression)cookie.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(cookie is null)) {
                h = h * 23 + cookie.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RevertStatement);
        } 
        
        public bool Equals(RevertStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Cookie, cookie)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RevertStatement left, RevertStatement right) {
            return EqualityComparer<RevertStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RevertStatement left, RevertStatement right) {
            return !(left == right);
        }
    
    }

}
