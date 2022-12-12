using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RestoreMasterKeyStatement : BackupRestoreMasterKeyStatementBase, IEquatable<RestoreMasterKeyStatement> {
        bool isForce = false;
        Literal encryptionPassword;
    
        public bool IsForce => isForce;
        public Literal EncryptionPassword => encryptionPassword;
    
        public RestoreMasterKeyStatement(bool isForce = false, Literal encryptionPassword = null, Literal file = null, Literal password = null) {
            this.isForce = isForce;
            this.encryptionPassword = encryptionPassword;
            this.file = file;
            this.password = password;
        }
    
        public ScriptDom.RestoreMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.RestoreMasterKeyStatement();
            ret.IsForce = isForce;
            ret.EncryptionPassword = (ScriptDom.Literal)encryptionPassword.ToMutable();
            ret.File = (ScriptDom.Literal)file.ToMutable();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isForce.GetHashCode();
            if (!(encryptionPassword is null)) {
                h = h * 23 + encryptionPassword.GetHashCode();
            }
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RestoreMasterKeyStatement);
        } 
        
        public bool Equals(RestoreMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForce, isForce)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.EncryptionPassword, encryptionPassword)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RestoreMasterKeyStatement left, RestoreMasterKeyStatement right) {
            return EqualityComparer<RestoreMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RestoreMasterKeyStatement left, RestoreMasterKeyStatement right) {
            return !(left == right);
        }
    
    }

}
