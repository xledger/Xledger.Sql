using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FunctionOption : TSqlFragment, IEquatable<FunctionOption> {
        protected ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption;
    
        public ScriptDom.FunctionOptionKind OptionKind => optionKind;
    
        public FunctionOption(ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FunctionOption ToMutableConcrete() {
            var ret = new ScriptDom.FunctionOption();
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
            return Equals(obj as FunctionOption);
        } 
        
        public bool Equals(FunctionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FunctionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FunctionOption left, FunctionOption right) {
            return EqualityComparer<FunctionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FunctionOption left, FunctionOption right) {
            return !(left == right);
        }
    
        public static FunctionOption FromMutable(ScriptDom.FunctionOption fragment) {
            return (FunctionOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
