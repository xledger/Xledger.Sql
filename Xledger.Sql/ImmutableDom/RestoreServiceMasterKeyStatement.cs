using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            ret.File = (ScriptDom.Literal)file?.ToMutable();
            ret.Password = (ScriptDom.Literal)password?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RestoreServiceMasterKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.isForce, othr.isForce);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.file, othr.file);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RestoreServiceMasterKeyStatement left, RestoreServiceMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RestoreServiceMasterKeyStatement FromMutable(ScriptDom.RestoreServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RestoreServiceMasterKeyStatement)) { throw new NotImplementedException("Unexpected subtype of RestoreServiceMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RestoreServiceMasterKeyStatement(
                isForce: fragment.IsForce,
                file: ImmutableDom.Literal.FromMutable(fragment.File),
                password: ImmutableDom.Literal.FromMutable(fragment.Password)
            );
        }
    
    }

}
