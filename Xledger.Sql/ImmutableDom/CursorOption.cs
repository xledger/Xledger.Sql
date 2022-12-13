using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorOption : TSqlFragment, IEquatable<CursorOption> {
        protected ScriptDom.CursorOptionKind optionKind = ScriptDom.CursorOptionKind.Local;
    
        public ScriptDom.CursorOptionKind OptionKind => optionKind;
    
        public CursorOption(ScriptDom.CursorOptionKind optionKind = ScriptDom.CursorOptionKind.Local) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CursorOption ToMutableConcrete() {
            var ret = new ScriptDom.CursorOption();
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
            return Equals(obj as CursorOption);
        } 
        
        public bool Equals(CursorOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CursorOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorOption left, CursorOption right) {
            return EqualityComparer<CursorOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorOption left, CursorOption right) {
            return !(left == right);
        }
    
        public static CursorOption FromMutable(ScriptDom.CursorOption fragment) {
            return (CursorOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
