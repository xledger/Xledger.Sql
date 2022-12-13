using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServiceMasterKeyStatement : TSqlStatement, IEquatable<AlterServiceMasterKeyStatement> {
        protected Literal account;
        protected Literal password;
        protected ScriptDom.AlterServiceMasterKeyOption kind = ScriptDom.AlterServiceMasterKeyOption.None;
    
        public Literal Account => account;
        public Literal Password => password;
        public ScriptDom.AlterServiceMasterKeyOption Kind => kind;
    
        public AlterServiceMasterKeyStatement(Literal account = null, Literal password = null, ScriptDom.AlterServiceMasterKeyOption kind = ScriptDom.AlterServiceMasterKeyOption.None) {
            this.account = account;
            this.password = password;
            this.kind = kind;
        }
    
        public ScriptDom.AlterServiceMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServiceMasterKeyStatement();
            ret.Account = (ScriptDom.Literal)account.ToMutable();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(account is null)) {
                h = h * 23 + account.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServiceMasterKeyStatement);
        } 
        
        public bool Equals(AlterServiceMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Account, account)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterServiceMasterKeyOption>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServiceMasterKeyStatement left, AlterServiceMasterKeyStatement right) {
            return EqualityComparer<AlterServiceMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServiceMasterKeyStatement left, AlterServiceMasterKeyStatement right) {
            return !(left == right);
        }
    
        public static AlterServiceMasterKeyStatement FromMutable(ScriptDom.AlterServiceMasterKeyStatement fragment) {
            return (AlterServiceMasterKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
