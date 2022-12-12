using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierPrincipalOption : PrincipalOption, IEquatable<IdentifierPrincipalOption> {
        protected Identifier identifier;
    
        public Identifier Identifier => identifier;
    
        public IdentifierPrincipalOption(Identifier identifier = null, ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration) {
            this.identifier = identifier;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IdentifierPrincipalOption ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierPrincipalOption();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentifierPrincipalOption);
        } 
        
        public bool Equals(IdentifierPrincipalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PrincipalOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierPrincipalOption left, IdentifierPrincipalOption right) {
            return EqualityComparer<IdentifierPrincipalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierPrincipalOption left, IdentifierPrincipalOption right) {
            return !(left == right);
        }
    
    }

}
