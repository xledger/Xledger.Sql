using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PrincipalOption : TSqlFragment, IEquatable<PrincipalOption> {
        ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration;
    
        public ScriptDom.PrincipalOptionKind OptionKind => optionKind;
    
        public PrincipalOption(ScriptDom.PrincipalOptionKind optionKind = ScriptDom.PrincipalOptionKind.CheckExpiration) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.PrincipalOption ToMutableConcrete() {
            var ret = new ScriptDom.PrincipalOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PrincipalOption);
        } 
        
        public bool Equals(PrincipalOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PrincipalOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PrincipalOption left, PrincipalOption right) {
            return EqualityComparer<PrincipalOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PrincipalOption left, PrincipalOption right) {
            return !(left == right);
        }
    
    }

}
