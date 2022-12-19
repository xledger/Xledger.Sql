using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityUserClause80 : TSqlFragment, IEquatable<SecurityUserClause80> {
        protected IReadOnlyList<Identifier> users;
        protected ScriptDom.UserType80 userType80 = ScriptDom.UserType80.Null;
    
        public IReadOnlyList<Identifier> Users => users;
        public ScriptDom.UserType80 UserType80 => userType80;
    
        public SecurityUserClause80(IReadOnlyList<Identifier> users = null, ScriptDom.UserType80 userType80 = ScriptDom.UserType80.Null) {
            this.users = ImmList<Identifier>.FromList(users);
            this.userType80 = userType80;
        }
    
        public ScriptDom.SecurityUserClause80 ToMutableConcrete() {
            var ret = new ScriptDom.SecurityUserClause80();
            ret.Users.AddRange(users.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.UserType80 = userType80;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + users.GetHashCode();
            h = h * 23 + userType80.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityUserClause80);
        } 
        
        public bool Equals(SecurityUserClause80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Users, users)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.UserType80>.Default.Equals(other.UserType80, userType80)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityUserClause80 left, SecurityUserClause80 right) {
            return EqualityComparer<SecurityUserClause80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityUserClause80 left, SecurityUserClause80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecurityUserClause80)that;
            compare = Comparer.DefaultInvariant.Compare(this.users, othr.users);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.userType80, othr.userType80);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SecurityUserClause80 left, SecurityUserClause80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SecurityUserClause80 left, SecurityUserClause80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SecurityUserClause80 left, SecurityUserClause80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SecurityUserClause80 left, SecurityUserClause80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SecurityUserClause80 FromMutable(ScriptDom.SecurityUserClause80 fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SecurityUserClause80)) { throw new NotImplementedException("Unexpected subtype of SecurityUserClause80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityUserClause80(
                users: fragment.Users.SelectList(ImmutableDom.Identifier.FromMutable),
                userType80: fragment.UserType80
            );
        }
    
    }

}
