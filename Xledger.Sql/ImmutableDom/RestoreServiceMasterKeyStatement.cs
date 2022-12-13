using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RestoreServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase, IEquatable<RestoreServiceMasterKeyStatement> {
        protected bool isForce = false;
    
        public bool IsForce => isForce;
    
        public RestoreServiceMasterKeyStatement(bool isForce = false, Literal file = null, Literal password = null) {
            this.isForce = isForce;
            this.file = file;
            this.password = password;
        }
    
        public ScriptDom.RestoreServiceMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.RestoreServiceMasterKeyStatement();
            ret.IsForce = isForce;
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
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RestoreServiceMasterKeyStatement);
        } 
        
        public bool Equals(RestoreServiceMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForce, isForce)) {
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
        
        public static bool operator ==(RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) {
            return EqualityComparer<RestoreServiceMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) {
            return !(left == right);
        }
    
        public static RestoreServiceMasterKeyStatement FromMutable(ScriptDom.RestoreServiceMasterKeyStatement fragment) {
            return (RestoreServiceMasterKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
