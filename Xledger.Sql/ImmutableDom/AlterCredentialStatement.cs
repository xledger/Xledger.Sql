using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterCredentialStatement : CredentialStatement, IEquatable<AlterCredentialStatement> {
        public AlterCredentialStatement(Identifier name = null, Literal identity = null, Literal secret = null, bool isDatabaseScoped = false) {
            this.name = name;
            this.identity = identity;
            this.secret = secret;
            this.isDatabaseScoped = isDatabaseScoped;
        }
    
        public ScriptDom.AlterCredentialStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterCredentialStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Identity = (ScriptDom.Literal)identity?.ToMutable();
            ret.Secret = (ScriptDom.Literal)secret?.ToMutable();
            ret.IsDatabaseScoped = isDatabaseScoped;
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
            if (!(identity is null)) {
                h = h * 23 + identity.GetHashCode();
            }
            if (!(secret is null)) {
                h = h * 23 + secret.GetHashCode();
            }
            h = h * 23 + isDatabaseScoped.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterCredentialStatement);
        } 
        
        public bool Equals(AlterCredentialStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Identity, identity)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Secret, secret)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDatabaseScoped, isDatabaseScoped)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterCredentialStatement left, AlterCredentialStatement right) {
            return EqualityComparer<AlterCredentialStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterCredentialStatement left, AlterCredentialStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterCredentialStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identity, othr.identity);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secret, othr.secret);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isDatabaseScoped, othr.isDatabaseScoped);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterCredentialStatement left, AlterCredentialStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterCredentialStatement left, AlterCredentialStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterCredentialStatement left, AlterCredentialStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterCredentialStatement left, AlterCredentialStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
