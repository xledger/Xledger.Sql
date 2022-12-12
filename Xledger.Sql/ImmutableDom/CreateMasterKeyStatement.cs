using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateMasterKeyStatement : MasterKeyStatement, IEquatable<CreateMasterKeyStatement> {
        public CreateMasterKeyStatement(Literal password = null) {
            this.password = password;
        }
    
        public ScriptDom.CreateMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateMasterKeyStatement();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateMasterKeyStatement);
        } 
        
        public bool Equals(CreateMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateMasterKeyStatement left, CreateMasterKeyStatement right) {
            return EqualityComparer<CreateMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateMasterKeyStatement left, CreateMasterKeyStatement right) {
            return !(left == right);
        }
    
    }

}