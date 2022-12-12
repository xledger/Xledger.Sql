using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentityValueKeyOption : KeyOption, IEquatable<IdentityValueKeyOption> {
        protected Literal identityPhrase;
    
        public Literal IdentityPhrase => identityPhrase;
    
        public IdentityValueKeyOption(Literal identityPhrase = null, ScriptDom.KeyOptionKind optionKind = ScriptDom.KeyOptionKind.KeySource) {
            this.identityPhrase = identityPhrase;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IdentityValueKeyOption ToMutableConcrete() {
            var ret = new ScriptDom.IdentityValueKeyOption();
            ret.IdentityPhrase = (ScriptDom.Literal)identityPhrase.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identityPhrase is null)) {
                h = h * 23 + identityPhrase.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentityValueKeyOption);
        } 
        
        public bool Equals(IdentityValueKeyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.IdentityPhrase, identityPhrase)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.KeyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentityValueKeyOption left, IdentityValueKeyOption right) {
            return EqualityComparer<IdentityValueKeyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentityValueKeyOption left, IdentityValueKeyOption right) {
            return !(left == right);
        }
    
    }

}
