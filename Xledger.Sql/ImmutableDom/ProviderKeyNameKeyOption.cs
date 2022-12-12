using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProviderKeyNameKeyOption : KeyOption, IEquatable<ProviderKeyNameKeyOption> {
        Literal keyName;
    
        public Literal KeyName => keyName;
    
        public ProviderKeyNameKeyOption(Literal keyName = null, ScriptDom.KeyOptionKind optionKind = ScriptDom.KeyOptionKind.KeySource) {
            this.keyName = keyName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ProviderKeyNameKeyOption ToMutableConcrete() {
            var ret = new ScriptDom.ProviderKeyNameKeyOption();
            ret.KeyName = (ScriptDom.Literal)keyName.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(keyName is null)) {
                h = h * 23 + keyName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ProviderKeyNameKeyOption);
        } 
        
        public bool Equals(ProviderKeyNameKeyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.KeyName, keyName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.KeyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProviderKeyNameKeyOption left, ProviderKeyNameKeyOption right) {
            return EqualityComparer<ProviderKeyNameKeyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProviderKeyNameKeyOption left, ProviderKeyNameKeyOption right) {
            return !(left == right);
        }
    
    }

}
