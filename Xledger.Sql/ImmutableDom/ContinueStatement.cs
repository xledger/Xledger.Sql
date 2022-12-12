using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ContinueStatement : TSqlStatement, IEquatable<ContinueStatement> {
        public ContinueStatement() {

        }
    
        public ScriptDom.ContinueStatement ToMutableConcrete() {
            var ret = new ScriptDom.ContinueStatement();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ContinueStatement);
        } 
        
        public bool Equals(ContinueStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(ContinueStatement left, ContinueStatement right) {
            return EqualityComparer<ContinueStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ContinueStatement left, ContinueStatement right) {
            return !(left == right);
        }
    
    }

}
