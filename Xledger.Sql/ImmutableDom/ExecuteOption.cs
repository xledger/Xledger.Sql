using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteOption : TSqlFragment, IEquatable<ExecuteOption> {
        protected ScriptDom.ExecuteOptionKind optionKind = ScriptDom.ExecuteOptionKind.Recompile;
    
        public ScriptDom.ExecuteOptionKind OptionKind => optionKind;
    
        public ExecuteOption(ScriptDom.ExecuteOptionKind optionKind = ScriptDom.ExecuteOptionKind.Recompile) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExecuteOption ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteOption();
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
            return Equals(obj as ExecuteOption);
        } 
        
        public bool Equals(ExecuteOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExecuteOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteOption left, ExecuteOption right) {
            return EqualityComparer<ExecuteOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteOption left, ExecuteOption right) {
            return !(left == right);
        }
    
        public static ExecuteOption FromMutable(ScriptDom.ExecuteOption fragment) {
            return (ExecuteOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
