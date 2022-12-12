using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CloseMasterKeyStatement : TSqlStatement, IEquatable<CloseMasterKeyStatement> {
        public CloseMasterKeyStatement() {

        }
    
        public ScriptDom.CloseMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CloseMasterKeyStatement();
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
            return Equals(obj as CloseMasterKeyStatement);
        } 
        
        public bool Equals(CloseMasterKeyStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(CloseMasterKeyStatement left, CloseMasterKeyStatement right) {
            return EqualityComparer<CloseMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CloseMasterKeyStatement left, CloseMasterKeyStatement right) {
            return !(left == right);
        }
    
    }

}