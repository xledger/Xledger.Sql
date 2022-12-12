using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RollbackTransactionStatement : TransactionStatement, IEquatable<RollbackTransactionStatement> {
        public RollbackTransactionStatement(IdentifierOrValueExpression name = null) {
            this.name = name;
        }
    
        public ScriptDom.RollbackTransactionStatement ToMutableConcrete() {
            var ret = new ScriptDom.RollbackTransactionStatement();
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RollbackTransactionStatement);
        } 
        
        public bool Equals(RollbackTransactionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RollbackTransactionStatement left, RollbackTransactionStatement right) {
            return EqualityComparer<RollbackTransactionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RollbackTransactionStatement left, RollbackTransactionStatement right) {
            return !(left == right);
        }
    
    }

}
