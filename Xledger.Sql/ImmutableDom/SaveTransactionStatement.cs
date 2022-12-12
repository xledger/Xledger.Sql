using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SaveTransactionStatement : TransactionStatement, IEquatable<SaveTransactionStatement> {
        public SaveTransactionStatement(IdentifierOrValueExpression name = null) {
            this.name = name;
        }
    
        public ScriptDom.SaveTransactionStatement ToMutableConcrete() {
            var ret = new ScriptDom.SaveTransactionStatement();
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
            return Equals(obj as SaveTransactionStatement);
        } 
        
        public bool Equals(SaveTransactionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SaveTransactionStatement left, SaveTransactionStatement right) {
            return EqualityComparer<SaveTransactionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SaveTransactionStatement left, SaveTransactionStatement right) {
            return !(left == right);
        }
    
    }

}
