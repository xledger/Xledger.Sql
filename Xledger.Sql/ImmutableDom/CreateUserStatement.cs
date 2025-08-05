using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateUserStatement : UserStatement, IEquatable<CreateUserStatement> {
        protected UserLoginOption userLoginOption;
    
        public UserLoginOption UserLoginOption => userLoginOption;
    
        public CreateUserStatement(UserLoginOption userLoginOption = null, Identifier name = null, IReadOnlyList<PrincipalOption> userOptions = null) {
            this.userLoginOption = userLoginOption;
            this.name = name;
            this.userOptions = userOptions.ToImmArray<PrincipalOption>();
        }
    
        public ScriptDom.CreateUserStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateUserStatement();
            ret.UserLoginOption = (ScriptDom.UserLoginOption)userLoginOption?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.UserOptions.AddRange(userOptions.Select(c => (ScriptDom.PrincipalOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(userLoginOption is null)) {
                h = h * 23 + userLoginOption.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + userOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateUserStatement);
        } 
        
        public bool Equals(CreateUserStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<UserLoginOption>.Default.Equals(other.UserLoginOption, userLoginOption)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.UserOptions, userOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateUserStatement left, CreateUserStatement right) {
            return EqualityComparer<CreateUserStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateUserStatement left, CreateUserStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateUserStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.userLoginOption, othr.userLoginOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.userOptions, othr.userOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateUserStatement left, CreateUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateUserStatement left, CreateUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateUserStatement left, CreateUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateUserStatement left, CreateUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateUserStatement FromMutable(ScriptDom.CreateUserStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateUserStatement)) { throw new NotImplementedException("Unexpected subtype of CreateUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateUserStatement(
                userLoginOption: ImmutableDom.UserLoginOption.FromMutable(fragment.UserLoginOption),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                userOptions: fragment.UserOptions.ToImmArray(ImmutableDom.PrincipalOption.FromMutable)
            );
        }
    
    }

}
