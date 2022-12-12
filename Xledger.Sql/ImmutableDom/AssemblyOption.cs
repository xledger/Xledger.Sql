using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssemblyOption : TSqlFragment, IEquatable<AssemblyOption> {
        ScriptDom.AssemblyOptionKind optionKind = ScriptDom.AssemblyOptionKind.PermissionSet;
    
        public ScriptDom.AssemblyOptionKind OptionKind => optionKind;
    
        public AssemblyOption(ScriptDom.AssemblyOptionKind optionKind = ScriptDom.AssemblyOptionKind.PermissionSet) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AssemblyOption ToMutableConcrete() {
            var ret = new ScriptDom.AssemblyOption();
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
            return Equals(obj as AssemblyOption);
        } 
        
        public bool Equals(AssemblyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AssemblyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AssemblyOption left, AssemblyOption right) {
            return EqualityComparer<AssemblyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AssemblyOption left, AssemblyOption right) {
            return !(left == right);
        }
    
    }

}
