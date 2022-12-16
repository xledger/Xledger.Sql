using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UserLoginOption : TSqlFragment, IEquatable<UserLoginOption> {
        protected ScriptDom.UserLoginOptionType userLoginOptionType = ScriptDom.UserLoginOptionType.Login;
        protected Identifier identifier;
    
        public ScriptDom.UserLoginOptionType UserLoginOptionType => userLoginOptionType;
        public Identifier Identifier => identifier;
    
        public UserLoginOption(ScriptDom.UserLoginOptionType userLoginOptionType = ScriptDom.UserLoginOptionType.Login, Identifier identifier = null) {
            this.userLoginOptionType = userLoginOptionType;
            this.identifier = identifier;
        }
    
        public ScriptDom.UserLoginOption ToMutableConcrete() {
            var ret = new ScriptDom.UserLoginOption();
            ret.UserLoginOptionType = userLoginOptionType;
            ret.Identifier = (ScriptDom.Identifier)identifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + userLoginOptionType.GetHashCode();
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UserLoginOption);
        } 
        
        public bool Equals(UserLoginOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.UserLoginOptionType>.Default.Equals(other.UserLoginOptionType, userLoginOptionType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UserLoginOption left, UserLoginOption right) {
            return EqualityComparer<UserLoginOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UserLoginOption left, UserLoginOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UserLoginOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.userLoginOptionType, othr.userLoginOptionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UserLoginOption left, UserLoginOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UserLoginOption left, UserLoginOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UserLoginOption left, UserLoginOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UserLoginOption left, UserLoginOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
