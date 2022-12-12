using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyCredentialOption : CopyStatementOptionBase, IEquatable<CopyCredentialOption> {
        StringLiteral identity;
        StringLiteral secret;
    
        public StringLiteral Identity => identity;
        public StringLiteral Secret => secret;
    
        public CopyCredentialOption(StringLiteral identity = null, StringLiteral secret = null) {
            this.identity = identity;
            this.secret = secret;
        }
    
        public ScriptDom.CopyCredentialOption ToMutableConcrete() {
            var ret = new ScriptDom.CopyCredentialOption();
            ret.Identity = (ScriptDom.StringLiteral)identity.ToMutable();
            ret.Secret = (ScriptDom.StringLiteral)secret.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identity is null)) {
                h = h * 23 + identity.GetHashCode();
            }
            if (!(secret is null)) {
                h = h * 23 + secret.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CopyCredentialOption);
        } 
        
        public bool Equals(CopyCredentialOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Identity, identity)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Secret, secret)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CopyCredentialOption left, CopyCredentialOption right) {
            return EqualityComparer<CopyCredentialOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CopyCredentialOption left, CopyCredentialOption right) {
            return !(left == right);
        }
    
    }

}