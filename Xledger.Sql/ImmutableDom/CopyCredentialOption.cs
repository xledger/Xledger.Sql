using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyCredentialOption : CopyStatementOptionBase, IEquatable<CopyCredentialOption> {
        protected StringLiteral identity;
        protected StringLiteral secret;
    
        public StringLiteral Identity => identity;
        public StringLiteral Secret => secret;
    
        public CopyCredentialOption(StringLiteral identity = null, StringLiteral secret = null) {
            this.identity = identity;
            this.secret = secret;
        }
    
        public ScriptDom.CopyCredentialOption ToMutableConcrete() {
            var ret = new ScriptDom.CopyCredentialOption();
            ret.Identity = (ScriptDom.StringLiteral)identity?.ToMutable();
            ret.Secret = (ScriptDom.StringLiteral)secret?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CopyCredentialOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.identity, othr.identity);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secret, othr.secret);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CopyCredentialOption left, CopyCredentialOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CopyCredentialOption left, CopyCredentialOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CopyCredentialOption left, CopyCredentialOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CopyCredentialOption left, CopyCredentialOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CopyCredentialOption FromMutable(ScriptDom.CopyCredentialOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CopyCredentialOption)) { throw new NotImplementedException("Unexpected subtype of CopyCredentialOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyCredentialOption(
                identity: ImmutableDom.StringLiteral.FromMutable(fragment.Identity),
                secret: ImmutableDom.StringLiteral.FromMutable(fragment.Secret)
            );
        }
    
    }

}
