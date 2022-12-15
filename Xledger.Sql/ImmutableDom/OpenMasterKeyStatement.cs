using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenMasterKeyStatement : TSqlStatement, IEquatable<OpenMasterKeyStatement> {
        protected Literal password;
    
        public Literal Password => password;
    
        public OpenMasterKeyStatement(Literal password = null) {
            this.password = password;
        }
    
        public ScriptDom.OpenMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.OpenMasterKeyStatement();
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
            return Equals(obj as OpenMasterKeyStatement);
        } 
        
        public bool Equals(OpenMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenMasterKeyStatement left, OpenMasterKeyStatement right) {
            return EqualityComparer<OpenMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenMasterKeyStatement left, OpenMasterKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenMasterKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OpenMasterKeyStatement left, OpenMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenMasterKeyStatement left, OpenMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenMasterKeyStatement left, OpenMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenMasterKeyStatement left, OpenMasterKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
