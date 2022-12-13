using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateUserStatement : UserStatement, IEquatable<CreateUserStatement> {
        protected UserLoginOption userLoginOption;
    
        public UserLoginOption UserLoginOption => userLoginOption;
    
        public CreateUserStatement(UserLoginOption userLoginOption = null, Identifier name = null, IReadOnlyList<PrincipalOption> userOptions = null) {
            this.userLoginOption = userLoginOption;
            this.name = name;
            this.userOptions = userOptions is null ? ImmList<PrincipalOption>.Empty : ImmList<PrincipalOption>.FromList(userOptions);
        }
    
        public ScriptDom.CreateUserStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateUserStatement();
            ret.UserLoginOption = (ScriptDom.UserLoginOption)userLoginOption.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.UserOptions.AddRange(userOptions.SelectList(c => (ScriptDom.PrincipalOption)c.ToMutable()));
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
    
        public static CreateUserStatement FromMutable(ScriptDom.CreateUserStatement fragment) {
            return (CreateUserStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
