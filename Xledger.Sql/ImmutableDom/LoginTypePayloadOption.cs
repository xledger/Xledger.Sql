using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LoginTypePayloadOption : PayloadOption, IEquatable<LoginTypePayloadOption> {
        protected bool isWindows = false;
    
        public bool IsWindows => isWindows;
    
        public LoginTypePayloadOption(bool isWindows = false, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isWindows = isWindows;
            this.kind = kind;
        }
    
        public ScriptDom.LoginTypePayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.LoginTypePayloadOption();
            ret.IsWindows = isWindows;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isWindows.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LoginTypePayloadOption);
        } 
        
        public bool Equals(LoginTypePayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsWindows, isWindows)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LoginTypePayloadOption left, LoginTypePayloadOption right) {
            return EqualityComparer<LoginTypePayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LoginTypePayloadOption left, LoginTypePayloadOption right) {
            return !(left == right);
        }
    
        public static LoginTypePayloadOption FromMutable(ScriptDom.LoginTypePayloadOption fragment) {
            return (LoginTypePayloadOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
