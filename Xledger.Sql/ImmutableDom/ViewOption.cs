using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewOption : TSqlFragment, IEquatable<ViewOption> {
        ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption;
    
        public ScriptDom.ViewOptionKind OptionKind => optionKind;
    
        public ViewOption(ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ViewOption ToMutableConcrete() {
            var ret = new ScriptDom.ViewOption();
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
            return Equals(obj as ViewOption);
        } 
        
        public bool Equals(ViewOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ViewOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ViewOption left, ViewOption right) {
            return EqualityComparer<ViewOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewOption left, ViewOption right) {
            return !(left == right);
        }
    
    }

}
