using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase, IEquatable<BackupServiceMasterKeyStatement> {
        public BackupServiceMasterKeyStatement(Literal file = null, Literal password = null) {
            this.file = file;
            this.password = password;
        }
    
        public ScriptDom.BackupServiceMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.BackupServiceMasterKeyStatement();
            ret.File = (ScriptDom.Literal)file.ToMutable();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupServiceMasterKeyStatement);
        } 
        
        public bool Equals(BackupServiceMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) {
            return EqualityComparer<BackupServiceMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BackupServiceMasterKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.file, othr.file);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BackupServiceMasterKeyStatement left, BackupServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BackupServiceMasterKeyStatement FromMutable(ScriptDom.BackupServiceMasterKeyStatement fragment) {
            return (BackupServiceMasterKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
