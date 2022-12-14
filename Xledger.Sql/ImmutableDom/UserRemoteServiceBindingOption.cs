using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UserRemoteServiceBindingOption : RemoteServiceBindingOption, IEquatable<UserRemoteServiceBindingOption> {
        protected Identifier user;
    
        public Identifier User => user;
    
        public UserRemoteServiceBindingOption(Identifier user = null, ScriptDom.RemoteServiceBindingOptionKind optionKind = ScriptDom.RemoteServiceBindingOptionKind.User) {
            this.user = user;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.UserRemoteServiceBindingOption ToMutableConcrete() {
            var ret = new ScriptDom.UserRemoteServiceBindingOption();
            ret.User = (ScriptDom.Identifier)user?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(user is null)) {
                h = h * 23 + user.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UserRemoteServiceBindingOption);
        } 
        
        public bool Equals(UserRemoteServiceBindingOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.User, user)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteServiceBindingOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) {
            return EqualityComparer<UserRemoteServiceBindingOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UserRemoteServiceBindingOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.user, othr.user);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UserRemoteServiceBindingOption left, UserRemoteServiceBindingOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UserRemoteServiceBindingOption FromMutable(ScriptDom.UserRemoteServiceBindingOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UserRemoteServiceBindingOption)) { throw new NotImplementedException("Unexpected subtype of UserRemoteServiceBindingOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserRemoteServiceBindingOption(
                user: ImmutableDom.Identifier.FromMutable(fragment.User),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
