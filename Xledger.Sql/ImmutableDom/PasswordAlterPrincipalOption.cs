using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PasswordAlterPrincipalOption : PrincipalOption, IEquatable<PasswordAlterPrincipalOption> {
        protected Literal password;
        protected Literal oldPassword;
        protected bool mustChange = false;
        protected bool unlock = false;
        protected bool hashed = false;
    
        public Literal Password => password;
        public Literal OldPassword => oldPassword;
        public bool MustChange => mustChange;
        public bool Unlock => unlock;
        public bool Hashed => hashed;
    
        public PasswordAlterPrincipalOption(Literal password = null, Literal oldPassword = null, bool mustChange = false, bool unlock = false, bool hashed = false, ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration) {
            this.password = password;
            this.oldPassword = oldPassword;
            this.mustChange = mustChange;
            this.unlock = unlock;
            this.hashed = hashed;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.PasswordAlterPrincipalOption ToMutableConcrete() {
            var ret = new ScriptDom.PasswordAlterPrincipalOption();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            ret.OldPassword = (ScriptDom.Literal)oldPassword.ToMutable();
            ret.MustChange = mustChange;
            ret.Unlock = unlock;
            ret.Hashed = hashed;
            ret.OptionKind = optionKind;
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
            if (!(oldPassword is null)) {
                h = h * 23 + oldPassword.GetHashCode();
            }
            h = h * 23 + mustChange.GetHashCode();
            h = h * 23 + unlock.GetHashCode();
            h = h * 23 + hashed.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PasswordAlterPrincipalOption);
        } 
        
        public bool Equals(PasswordAlterPrincipalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.OldPassword, oldPassword)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.MustChange, mustChange)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Unlock, unlock)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Hashed, hashed)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PrincipalOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PasswordAlterPrincipalOption left, PasswordAlterPrincipalOption right) {
            return EqualityComparer<PasswordAlterPrincipalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PasswordAlterPrincipalOption left, PasswordAlterPrincipalOption right) {
            return !(left == right);
        }
    
        public static PasswordAlterPrincipalOption FromMutable(ScriptDom.PasswordAlterPrincipalOption fragment) {
            return (PasswordAlterPrincipalOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
